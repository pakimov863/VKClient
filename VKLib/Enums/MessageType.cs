using System;

namespace VKLib.Enums
{
	/// <summary>
	/// Тип сообщения.
	/// </summary>
	[Serializable]
	public enum MessageType
    {
        /// <summary>
        /// Полученное сообщение.
        /// </summary>
        Received = 0,

        /// <summary>
        /// Отправленное сообщение.
        /// </summary>
        Sended = 1
    }
}