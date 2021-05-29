﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kula.Util;
using kula.Core;

namespace kula.Data
{
    delegate void KvmBuiltinFunc(Stack<object> stack);
    class Func  // : IRunnable
    {
        // 静态内置方法 们
        public static Dictionary<string, KvmBuiltinFunc> BuiltinFunc { get => builtinFunc; }
        private static readonly Dictionary<string, KvmBuiltinFunc> builtinFunc = new Dictionary<string, KvmBuiltinFunc>()
        {
            {"plus", (stack) => {
                var args = new object[2];
                for(int i = args.Length - 1; i >= 0; --i) {args[i] = stack.Pop(); }
                foreach (var arg in args) {if (arg.GetType() != typeof(float)) throw new KulaException.FuncException(); }
                stack.Push((float)args[0] + (float)args[1]);
            } },
            {"minus", (stack) => {
                var args = new object[2];
                for(int i = args.Length - 1; i >= 0; --i) {args[i] = stack.Pop(); }
                foreach (var arg in args) {if (arg.GetType() != typeof(float)) throw new KulaException.FuncException(); }
                stack.Push((float)args[0] - (float)args[1]);
            } },
            {"times", (stack) => {
                var args = new object[2];
                for(int i = args.Length - 1; i >= 0; --i) {args[i] = stack.Pop(); }
                foreach (var arg in args) {if (arg.GetType() != typeof(float)) throw new KulaException.FuncException(); }
                stack.Push((float)args[0] * (float)args[1]);
            } },
            {"div", (stack) => {
                var args = new object[2];
                for(int i = args.Length - 1; i >= 0; --i) {args[i] = stack.Pop(); }
                foreach (var arg in args) {if (arg.GetType() != typeof(float)) throw new KulaException.FuncException(); }
                stack.Push((float)args[0] / (float)args[1]);
            } },
            {"println", (stack) => {
                Console.WriteLine( stack.Pop() );
            } },
            {"input", (stack) =>{
                stack.Push(Console.ReadLine());
            } },
            {"toStr", (stack) => {
                stack.Push(stack.Pop().ToString());
            } },
            {"toNum", (stack) => {
                var arg = stack.Pop();
                if (arg.GetType() != typeof(string))
                    throw new KulaException.FuncException();
                float.TryParse((string)arg, out float ans);
                stack.Push(ans);
            } },
            {"cut", (stack) => {
                var args = new object[3];
                for(int i = args.Length - 1; i >= 0; --i) { args[i] = stack.Pop(); }
                if (args[0].GetType() == typeof(string) || args[1].GetType() == typeof(float) || args[2].GetType() == typeof(float))
                    stack.Push(((string)args[0]).Substring((int)(float)args[1], (int)(float)args[2]));
                else
                    throw new KulaException.FuncException();
            } },
            {"concat", (stack)=> {
                var args = new object[2];
                for(int i = args.Length - 1; i >= 0; --i) {args[i] = stack.Pop(); }
                foreach (var arg in args)
                    if (arg.GetType() != typeof(string)) { throw new KulaException.FuncException(); }
                stack.Push((string)args[0] + (string)args[1]);
            } },
            {"type", (stack)=> {
                var arg_type = stack.Pop().GetType();
                switch (Type.GetTypeCode(arg_type))
                {
                    case TypeCode.Single:
                        stack.Push("Num");
                        break;
                    case TypeCode.String:
                        stack.Push("Str");
                        break;
                    default:
                        if(arg_type == typeof(Func))
                            stack.Push("Func");
                        else
                            stack.Push("None");
                        break;
                }
            } },
            {"equal", (stack)=> {
                stack.Push( object.Equals(stack.Pop(), stack.Pop() ) ? 1f : 0f);
            } },
            {"greater", (stack)=> {
                var args = new object[2];
                for(int i = args.Length - 1; i >= 0; --i) {args[i] = stack.Pop(); }
                foreach (var arg in args) {if (arg.GetType() != typeof(float)) throw new KulaException.FuncException(); }
                stack.Push( ((float)args[0] > (float)args[1]) ? 1f : 0f);
            } },
            {"less", (stack)=> {
                var args = new object[2];
                for(int i = args.Length - 1; i >= 0; --i) {args[i] = stack.Pop(); }
                foreach (var arg in args) {if (arg.GetType() != typeof(float)) throw new KulaException.FuncException(); }
                stack.Push( ((float)args[0] < (float)args[1]) ? 1f : 0f);
            } },
            {"and", (stack) => {
                var args = new object[2];
                for(int i = args.Length - 1; i >= 0; --i) {args[i] = stack.Pop(); }
                foreach (var arg in args) {if (arg.GetType() != typeof(float)) throw new KulaException.FuncException(); }
                bool flag = ((float)args[0] != 0) && ((float)args[1] != 0);
                stack.Push(flag ? 1f : 0f);
            } },
            {"or", (stack) => {
                var args = new object[2];
                for(int i = args.Length - 1; i >= 0; --i) {args[i] = stack.Pop(); }
                foreach (var arg in args) {if (arg.GetType() != typeof(float)) throw new KulaException.FuncException(); }
                bool flag = ((float)args[0] != 0) || ((float)args[1] != 0);
                stack.Push(flag ? 1f : 0f);
            } },
            {"not", (stack) => {
                var arg = stack.Pop();
                if (arg.GetType() != typeof(float)) { throw new KulaException.FuncException(); }
                stack.Push((float)arg == 0f ? 1f : 0f);
            } },
        };

        // 接口儿
        public FuncRuntime FatherRuntime { get => fatherRuntime; set => fatherRuntime = value; }
        public List<LexToken> TokenStream { get => tokenStream; }
        public List<KvmNode> NodeStream { get => nodeStream; }
        public List<Type> ArgTypes { get => argTypes; }
        public List<string> ArgNames { get => argNames; }
        public Type ReturnType { get => returnType; set => returnType = value; }

        private FuncRuntime fatherRuntime;
        private readonly List<LexToken> tokenStream;
        private readonly List<KvmNode> nodeStream;
        
        private readonly List<Type> argTypes;
        private readonly List<string> argNames;
        private Type returnType;

        public Func(List<LexToken> tokenStream)
        {
            this.tokenStream = tokenStream;

            this.argTypes = new List<Type>();
            this.argNames = new List<string>();
            this.nodeStream = new List<KvmNode>();
        }

        public override string ToString()
        {
            return "{----}";
        }
    }
}
