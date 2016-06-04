using System;
using VKLib.Utils;

namespace VKLib.Model.Attachments
{
	[Obsolete("Для версии API ниже 5.0")]
	[Serializable]
	public class PhotosList : MediaAttachment
    {
        static PhotosList()
        {
            RegisterType(typeof(PhotosList), "photos_list");
        }

        #region Private Methods

        internal static PhotosList FromJson(VkResponse response)
        {
            var list = new PhotosList();

            return list;
        }

        #endregion
    }
}