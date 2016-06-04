using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace VKClient
{
    class SettingController
    {
        public enum Format
        {
            TextFormat = 0,
            IniFormat = 1,
            CryptoFormat = 2
        };

        public enum Scope
        {
            UserScope = 0, //%APPDATA%
            SystemScope = 1, //%COMMON_APPDATA%
            AppScope = 2 //%APPDIR%
        };

        public enum Status
        {
            NoError = 0,
            AccessError = 1,
            FormatError = 2
        };

        //Переменные

        private Format _Format;
        private Scope _Scope;
        private Status _Status;
        private String _Organization;
        private String _Application;
        private String _FileName;

        private StreamReader _SR;
        private StreamWriter _SW;
        private String _CurrentGroup = "";

        //Конструктры

        public SettingController(String organization, String application)
        {
            this._Format = Format.TextFormat;
            this._Scope = Scope.AppScope;
            this._Status = Status.NoError;
            this._Organization = organization;
            this._Application = application;
            this._FileName = "settings";
        }

        public SettingController(Scope scope, String organization, String application)
        {
            this._Format = Format.TextFormat;
            this._Scope = scope;
            this._Status = Status.NoError;
            this._Organization = organization;
            this._Application = application;
            this._FileName = "settings";
        }

        public SettingController(Format format, Scope scope, String organization, String application)
        {
            this._Format = format;
            this._Scope = scope;
            this._Status = Status.NoError;
            this._Organization = organization;
            this._Application = application;
            this._FileName = "settings";
        }

        public SettingController(String fileName, Format format)
        {
            this._Format = format;
            this._Scope = Scope.AppScope;
            this._Status = Status.NoError;
            this._Organization = "DefaultOrganization";
            this._Application = "DefaultApplication";
            this._FileName = fileName;
        }

        public SettingController()
        {
            this._Format = Format.TextFormat;
            this._Scope = Scope.AppScope;
            this._Status = Status.NoError;
            this._Organization = "DefaultOrganization";
            this._Application = "DefaultApplication";
            this._FileName = "settings";
        }

        //Функции

        void GetFilePath(ref String filePath)
        {
            if (this._Status != Status.NoError) return;

            if (this._Scope == Scope.AppScope) filePath = Environment.CurrentDirectory.ToString() + "\\" + this._FileName;
            else if (this._Scope == Scope.UserScope) filePath = Environment.SpecialFolder.ApplicationData.ToString() + "\\" + this._FileName;
            else if (this._Scope == Scope.SystemScope) filePath = Environment.SpecialFolder.CommonApplicationData.ToString() + "\\" + this._FileName;
            else
            {
                this._Status = Status.FormatError;
                return;
            }

            if (this._Format == Format.IniFormat) filePath += ".ini";
            else if (this._Format == Format.TextFormat) filePath += ".set";
            //else if (this._Format == Format.CryptoFormat) filePath += ".cset";
            else
            {
                this._Status = Status.FormatError;
                return;
            }
        }

        /// <summary>
        /// Returns a list of all keys, including subkeys, that can be read using the QSettings object.
        /// </summary>
        /// <returns></returns>
        List<String> allKeys()
        {
            String filePath = "";
            GetFilePath(ref filePath);

            if (this._Status != Status.NoError) return null;

            List<String> retData = new List<string>();
            _SR = new StreamReader(filePath);
            try
            {
                while (!_SR.EndOfStream)
                {
                    String line = _SR.ReadLine();
                    if (this._Format == Format.IniFormat || this._Format == Format.TextFormat)
                    {
                        String adLine = line.Substring(0, line.IndexOf("=") + 1).Trim();
                        if (adLine != "" || !(adLine.Contains("[") && adLine.Contains("]"))) retData.Add(adLine);
                    }
                    /*else if (this._Format == Format.CryptoFormat)
                    {
                        
                    }*/
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch
            {
                this._Status = Status.AccessError;
                return null;
            }
            finally
            {
                _SR.Close();
                _SR.Dispose();
            }
            return retData;
        }

        /// <summary>
        /// Returns the application name used for storing the settings.
        /// </summary>
        /// <returns></returns>
        String applicationName()
        {
            return this._Application;
        }

        /// <summary>
        /// Appends prefix to the current group.
        /// </summary>
        /// <param name="prefix"></param>
        void beginGroup(string prefix)
        {
            String filePath = "";
            GetFilePath(ref filePath);

            if (this._Status != Status.NoError) return;

            _SW = new StreamWriter(filePath, true);
            try
            {
                if (this._Format == Format.IniFormat)
                {
                    _SW.WriteLine("[" + prefix + "]");
                }
                else if (this._Format == Format.TextFormat)
                {
                    if (this._CurrentGroup == "") _SW.WriteLine("[" + prefix + "]");
                    else _SW.WriteLine("[" + this._CurrentGroup + "|" + prefix + "]");
                }
                /*else if (this._Format == Format.CryptoFormat)
                {
                        
                }*/
                else
                {
                    throw new Exception();
                }

                if (this._CurrentGroup == "") this._CurrentGroup = prefix;
                else this._CurrentGroup += "|" + prefix;
            }
            catch
            {
                this._Status = Status.AccessError;
                return;
            }
            finally
            {
                _SW.Close();
                _SW.Dispose();
            }
        }

        /// <summary>
        /// Adds prefix to the current group and starts reading from an array. Returns the size of the array.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        int beginReadArray(string prefix)
        {
            return 0;
        }

        /// <summary>
        /// Adds prefix to the current group and starts writing an array of size size. If size is -1 (the default), it is automatically determined based on the indexes of the entries written.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="size"></param>
        void beginWriteArray(string prefix, int size = -1)
        {
            return;
        }

        /// <summary>
        /// Returns a list of all key top-level groups that contain keys that can be read using the QSettings object.
        /// </summary>
        /// <returns></returns>
        List<String> childGroups()
        {
            //NO DATA!
            return null;
        }

        /// <summary>
        /// Returns a list of all top-level keys that can be read using the QSettings object.
        /// </summary>
        /// <returns></returns>
        List<String> childKeys()
        {
            //NO DATA!
            return null;
        }

        /// <summary>
        /// Removes all entries in the primary location associated to this QSettings object.
        /// </summary>
        /// <param name="all"></param>
        void clear(bool all = false)
        {

        }

        /// <summary>
        /// Returns true if there exists a setting called key; returns false otherwise.
        /// </summary>
        /// <returns></returns>
        bool contains(String key)
        {
            String filePath = "";
            GetFilePath(ref filePath);

            if (this._Status != Status.NoError) return false;

            bool retData = false;
            _SR = new StreamReader(filePath);
            try
            {
                while (!_SR.EndOfStream && !retData)
                {
                    String line = _SR.ReadLine();
                    if (this._Format == Format.IniFormat || this._Format == Format.TextFormat)
                    {
                        String adLine = line.Substring(0, line.IndexOf("=") + 1).Trim();
                        if (adLine == key) retData = true;
                    }
                    /*else if (this._Format == Format.CryptoFormat)
                    {
                        
                    }*/
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch
            {
                this._Status = Status.AccessError;
                return false;
            }
            finally
            {
                _SR.Close();
                _SR.Dispose();
            }
            return retData;
        }

        /// <summary>
        /// Closes the array that was started using beginReadArray() or beginWriteArray().
        /// </summary>
        void endArray()
        {

        }

        /// <summary>
        /// Resets the group to what it was before the corresponding beginGroup() call.
        /// </summary>
        void endGroup()
        {

        }

        /// <summary>
        /// Returns the path where settings written using this QSettings object are stored.
        /// </summary>
        /// <returns></returns>
        String fileName()
        {
            return this._FileName;
        }

        /// <summary>
        /// Returns the format used for storing the settings.
        /// </summary>
        /// <returns></returns>
        Format format()
        {
            return this._Format;
        }

        /// <summary>
        /// Returns the current group.
        /// </summary>
        /// <returns></returns>
        String group(bool onlyCurrent = true)
        {
            if (onlyCurrent) return this._CurrentGroup.Split('|').Last();
            else return this._CurrentGroup;
        }

        /// <summary>
        /// Returns true if settings can be written using this QSettings object; returns false otherwise.
        /// </summary>
        /// <returns></returns>
        bool isWritable()
        {
            //NO DATA!
            return false;
        }

        /// <summary>
        /// Returns the organization name used for storing the settings.
        /// </summary>
        /// <returns></returns>
        String organizationName()
        {
            //NO DATA!
            return "";
        }

        /// <summary>
        /// Removes the setting key and any sub-settings of key.
        /// </summary>
        /// <param name="key"></param>
        void remove(String key)
        {

        }

        /// <summary>
        /// Returns the scope used for storing the settings.
        /// </summary>
        /// <returns></returns>
        Scope scope()
        {
            return this._Scope;
        }

        /// <summary>
        /// Sets the current array index to i. Calls to functions such as setValue(), value(), remove(), and contains() will operate on the array entry at that index.
        /// </summary>
        /// <param name="i"></param>
        void setArrayIndex(int i)
        {

        }

        /// <summary>
        /// Sets the value of setting key to value. If the key already exists, the previous value is overwritten.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void setValue(String key, Object value)
        {

        }

        /// <summary>
        /// Returns a status code indicating the first error that was met by QSettings, or QSettings::NoError if no error occurred.
        /// </summary>
        /// <returns></returns>
        Status status()
        {
            return this._Status;
        }

        /// <summary>
        /// Returns the value for setting key. If the setting doesn't exist, returns defaultValue.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        Object value(String key, Object defaultValue)
        {
            //NO DATA!
            return null;
        }
    }
}
