using System;
using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// Assert や Debug.LogError、Exception が発生したかどうかを確認できるクラス
    /// </summary>
    public sealed class CheckErrorLogScope : IDisposable
    {
        //================================================================================
        // プロパティ
        //================================================================================
        public bool IsError { get; private set; }

        public bool IsSuccess => !IsError;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CheckErrorLogScope()
        {
            Application.logMessageReceivedThreaded += OnLogMessageReceivedThreaded;
        }

        /// <summary>
        /// 破棄します
        /// </summary>
        public void Dispose()
        {
            Application.logMessageReceivedThreaded -= OnLogMessageReceivedThreaded;
        }

        /// <summary>
        /// ログ出力された時に呼び出されます
        /// </summary>
        private void OnLogMessageReceivedThreaded
        (
            string  condition,
            string  trace,
            LogType type
        )
        {
            if ( IsError ) return;

            IsError = type is
                    LogType.Assert or
                    LogType.Error or
                    LogType.Exception
                ;

            if ( !IsError ) return;

            Application.logMessageReceivedThreaded -= OnLogMessageReceivedThreaded;
        }
    }
}