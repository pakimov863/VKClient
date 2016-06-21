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
        //Dictionary<string, Dictionary<string, Object>>
        //group -> key -> data

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

        // Переменные

        private Format _Format;
        private Scope _Scope;
        private Status _Status;
        private String _FileName;
        private Dictionary<String, Dictionary<String, Object>> _Data;

        private StreamReader _SR;
        private StreamWriter _SW;

        // Конструктры

        public SettingController(Boolean rewrite = false)
        {
            _Format = Format.TextFormat;
            _Scope = Scope.AppScope;
            _Status = Status.NoError;
            _Data = new Dictionary<String, Dictionary<String, Object>>();
            _FileName = "settings.set";
            if (rewrite && File.Exists(_FileName)) File.Delete(_FileName);
        }

        public SettingController(String file, Boolean rewrite = false)
        {
            _Format = Format.TextFormat;
            _Scope = Scope.AppScope;
            _Status = Status.NoError;
            _Data = new Dictionary<String, Dictionary<String, Object>>();
            _FileName = file;
            if (rewrite && File.Exists(_FileName)) File.Delete(_FileName);
        }

        public SettingController(Format format, Scope scope, String file, Boolean rewrite = false)
        {
            _Format = format;
            _Scope = scope;
            _Status = Status.NoError;
            _Data = new Dictionary<String, Dictionary<String, Object>>();
            _FileName = file;
            if (rewrite && File.Exists(_FileName)) File.Delete(_FileName);
        }

        // Функции

        /// <summary>
        /// Загружает настройки из файла
        /// </summary>
        /// <returns>true, если не было ошибок</returns>
        public bool load()
        {
            _SR = new StreamReader(_FileName);
            clear();

            String currentGroup = "";
            while(!_SR.EndOfStream)
            {
                String rstring = _SR.ReadLine();
                if (_Format == Format.IniFormat)
                {
                    if (rstring.Trim().StartsWith("#") || rstring.Trim().StartsWith(";")) continue;
                    if (rstring.Trim().StartsWith("[") && rstring.Contains("]"))
                    {
                        String sect = rstring.Trim().Substring(1, rstring.IndexOf("]"));
                        if (!_Data.ContainsKey(sect.ToLower())) _Data.Add(sect.ToLower(), new Dictionary<string, object>());
                        currentGroup = sect.ToLower();
                        continue;
                    }

                    String[] rdata = rstring.Trim().Split(new Char[]{'=', ';'});
                    if (String.IsNullOrWhiteSpace(currentGroup)) currentGroup = "default";
                    setValue(rdata[0].Trim(), rdata[1].Trim(), currentGroup);
                }
                else
                    throw new Exception();
                
            }
            
            _SR.Close();
            return true;
        }

        /// <summary>
        /// Сохраняет настройки из массива в файл
        /// </summary>
        /// <returns>true, если не было ошибок</returns>
        public bool save()
        {
            _SW = new StreamWriter(_FileName, false);
            foreach(String group in _Data.Keys)
            {
                if (_Format == Format.IniFormat)
                {
                    _SW.WriteLine("[" + group + "]");
                }
                else
                    throw new Exception();
                for (int i = 0; i < _Data[group].Count; i++)
                {
                    if (_Format == Format.IniFormat)
                    {
                        _SW.WriteLine(_Data[group].ElementAt(i).Key + "=" + _Data[group].ElementAt(i).Value.ToString());
                    }
                    else
                        throw new Exception();
                }
            }
            
            _SW.Close();
            return true;
        }

        /// <summary>
        /// Возвращает все ключи определенной группы или null
        /// </summary>
        /// <param name="group">Группа для проверки</param>
        /// <returns>Список ключей</returns>
        public List<String> allKeys(String group = "default")
        {
            if (_Data == null) return null;
            if (String.IsNullOrWhiteSpace(group)) return null;
            if (!_Data.ContainsKey(group)) return null;
            if (_Data[group] == null) return null;
            return _Data[group].Keys.ToList();
        }

        /// <summary>
        /// Очищает настройки полностью или только определенную группу
        /// </summary>
        /// <param name="group">Группа для очистки</param>
        public void clear(String group = "")
        {
            if (String.IsNullOrWhiteSpace(group))
            {
                if (_Data != null) _Data.Clear();
                _Data = new Dictionary<String, Dictionary<String, Object>>();
            }
            else
            {
                if (!_Data.ContainsKey(group)) return;
                if (_Data[group] != null) _Data[group].Clear();
                _Data[group] = new Dictionary<String, Object>();
            }
        }

        /// <summary>
        /// Возвращает true, если указанный ключ существует в указанной группе
        /// </summary>
        /// <param name="key">Ключ для поиска</param>
        /// <param name="group">Группа для поиска</param>
        /// <returns></returns>
        public Boolean contains(String key, String group = "default")
        {
            if (_Data == null) return false;
            if (String.IsNullOrWhiteSpace(group)) return false;
            if (!_Data.ContainsKey(group)) return false;
            if (_Data[group] == null) return false;
            if (String.IsNullOrWhiteSpace(key)) return false;
            return _Data[group].ContainsKey(key);
        }

        /// <summary>
        /// Возвращает имя рабочего файла
        /// </summary>
        /// <returns></returns>
        public String fileName()
        {
            return _FileName;
        }

        /// <summary>
        /// Возвращает тип рабочего файла
        /// </summary>
        /// <returns></returns>
        public Format format()
        {
            return _Format;
        }

        /// <summary>
        /// Возвращает хранилище рабочего файла
        /// </summary>
        /// <returns></returns>
        public Scope scope()
        {
            return _Scope;
        }

        /// <summary>
        /// Возвращает текущее состояние
        /// </summary>
        /// <returns></returns>
        public Status status()
        {
            return _Status;
        }

        /// <summary>
        /// Удаляет ключ в указанной группе
        /// </summary>
        /// <param name="key">Ключ для удаления</param>
        /// <param name="group">Группа, содержащая ключ</param>
        public void removeKey(String key, String group = "default")
        {
            if (_Data == null) return;
            if (String.IsNullOrWhiteSpace(group)) return;
            if (!_Data.ContainsKey(group)) return;
            if (String.IsNullOrWhiteSpace(key)) return;
            _Data[group].Remove(key);
        }

        /// <summary>
        /// Удаляет группу настроек
        /// </summary>
        /// <param name="group">Группа для удаления</param>
        public void removeGroup(String group)
        {
            if (_Data == null) return;
            if (String.IsNullOrWhiteSpace(group)) return;
            _Data.Remove(group);
        }

        /// <summary>
        /// Устанавливает значение ключа в заданной группе
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение для сохранения</param>
        /// <param name="group">Группа, содержащая ключ</param>
        public void setValue(String key, Object value, String group = "default")
        {
            if (_Data == null) return;
            if (String.IsNullOrWhiteSpace(group)) return;
            if (!_Data.ContainsKey(group)) return;
            if (String.IsNullOrWhiteSpace(key)) return;
            if (_Data[group] == null) return;
            if (value == null) return;

            if (_Data[group].ContainsKey(key)) _Data[group][key] = value;
            else _Data[group].Add(key, value);
        }

        /// <summary>
        /// Возвращает значение по ключу
        /// </summary>
        /// <param name="key">Ключ для поиска</param>
        /// <param name="group">Группа, содержащая ключ</param>
        /// <param name="defaultValue">Значение, возвращаемое в случае ненайденного ключа</param>
        /// <returns></returns>
        public Object getValue(String key, String group = "default", Object defaultValue = null)
        {
            if (_Data == null) return defaultValue;
            if (String.IsNullOrWhiteSpace(group)) return defaultValue;
            if (!_Data.ContainsKey(group)) return defaultValue;
            if (String.IsNullOrWhiteSpace(key)) return defaultValue;
            if (_Data[group] == null) return defaultValue;

            if (_Data[group].ContainsKey(key)) return _Data[group][key];
            else return defaultValue;
        }
    }
}
