﻿using System;

namespace Maha.JsonService
{
    /// <summary>
    /// 预处理程序
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public delegate JsonRpcException PreProcessHandler(JsonRpcRequestContext request, object context);

    /// <summary>
    /// 完成时处理程序
    /// </summary>
    /// <param name="request"></param>
    /// <param name="response"></param>
    /// <param name="context"></param>
    public delegate void CompletedProcessHandler(JsonRpcRequestContext request, JsonRpcResponseContext response, object context);

    /// <summary>
    /// JsonRpc全局配置管理器
    /// </summary>
    public static class JsonRpcConfigManager
    {
        /// <summary>
        /// 设置默认会话上预处理程序
        /// </summary>
        /// <param name="handler"></param>
        public static void SetPreProcessHandler(PreProcessHandler handler)
        {
            Handler.DefaultHandler.SetPreProcessHandler(handler);
        }

        /// <summary>
        /// 设置默认会话上预处理处理程序。
        /// </summary>
        /// <param name="handler"></param>
        public static void SetCompletedProcessHandler(CompletedProcessHandler handler)
        {
            Handler.DefaultHandler.SetCompletedProcessHandler(handler);
        }

        /// <summary>
        /// 设置特定会话上预处理程序
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="handler"></param>
        public static void SetBeforeProcessHanlder(string sessionId, PreProcessHandler handler)
        {
            Handler.GetSessionHandler(sessionId).SetPreProcessHandler(handler);
        }

        /// <summary>
        /// 设置默认会话上异常处理程序
        /// </summary>
        public static void SetErrorHandler(Func<JsonRpcRequestContext, JsonRpcException, JsonRpcException> handler)
        {
            Handler.DefaultHandler.SetErrorHandler(handler);
        }

        /// <summary>
        /// 设置特定会话上异常处理程序
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="handler"></param>
        public static void SetErrorHandler(string sessionId, Func<JsonRpcRequestContext, JsonRpcException, JsonRpcException> handler)
        {
            Handler.GetSessionHandler(sessionId).SetErrorHandler(handler);
        }

        /// <summary>
        /// 设置默认会话上转换错误处理程序
        /// </summary>
        /// <param name="handler"></param>
        public static void SetParseErrorHandler(Func<string, JsonRpcException, JsonRpcException> handler)
        {
            Handler.DefaultHandler.SetParseErrorHandler(handler);
        }

        /// <summary>
        /// 设置特定会话上转换错误处理程序
        /// </summary>
        /// <param name="handler"></param>
        public static void SetParseErrorHandler(string sessionId, Func<string, JsonRpcException, JsonRpcException> handler)
        {
            Handler.GetSessionHandler(sessionId).SetParseErrorHandler(handler);
        }
    }
}
