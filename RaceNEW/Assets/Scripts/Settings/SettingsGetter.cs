using System;
using System.Collections.Generic;
using System.Linq;
using Cars;
using Newtonsoft.Json;
using UnityEngine;

namespace Sliders
{
    public class SettingsGetter
    {
        public struct Builder
        {
            internal Setting.Data[] _settings;
            private readonly bool _isFullName, _hasExclusions;
            private readonly List<string> _exclusions;
            private readonly string _name;

            public Setting.Data Setting
            {
                get
                {
                    var builder = this;
                    _settings = _settings.Where(t =>
                    {
                        if (builder._hasExclusions)
                        {
                            if (!t.Name.Contains(builder._name)) return false;
                            foreach (var exclusion in builder._exclusions)
                            {
                                if (t.Name.Contains(exclusion)) return false;
                            }

                            return true;
                        }

                        else if (builder._isFullName)
                        {
                            return t.Name == builder._name;
                        }

                        return t.Name.Contains(builder._name);
                    }).ToArray();
#if DEBUG
                    if (_settings.Length != 1)
                    {
                        throw new PossibleUnexpectedBehaviour($"Count of settings by name {_name} is {_settings.Length}");
                    }
#endif
                    return _settings[0];
                }
            }

            private Builder(Setting.Data[] settings, bool isFullName, bool hasExclusions, List<string> exclusions,
                string name)
            {
                _settings = settings;
                _isFullName = isFullName;
                _hasExclusions = hasExclusions;
                _exclusions = exclusions ?? new List<string>();
                _name = name;
            }

            public Builder WithExclusion(string exclusion)
            {
#if DEBUG
                if (_isFullName)
                    throw new PossibleUnexpectedBehaviour(
                        "Is full name equals true. You can't use exclusions with full name");
                if (_exclusions.Contains(exclusion))
                    throw new ArgumentException($"Exclusions already contain {exclusion}");
#endif
                _exclusions.Add(exclusion);
                return new Builder(_settings, _isFullName, true, _exclusions, _name);
            }

            public Builder WithFullName(string fullName)
            {
#if DEBUG
                if (_isFullName) throw new Exception("Extra WithFullName() invocation");
                if (_hasExclusions)
                    throw new PossibleUnexpectedBehaviour(
                        "HasExclusions equals true. You can't use exclusions with full name");
#endif
                return new Builder(_settings, true, _hasExclusions, _exclusions, fullName);
            }

            public Builder WithNotFullName(string settingName)
            {
#if DEBUG
                if (_isFullName) throw new PossibleUnexpectedBehaviour("Is full name equals true");
#endif
                return new Builder(_settings, false, _hasExclusions, _exclusions, settingName);
            }
        }

        public const string SavePath = "Settings";
        private readonly Setting.Data[] _settings;

        public SettingsGetter()
        {
            _settings =
                JsonConvert.DeserializeObject<Setting.Data[]>(
                    PlayerPrefs.GetString(SavePath));
        }

        public Builder StartBuild()
        {
            var builder = new Builder();
            ref var builderRef = ref builder;
            builderRef._settings = _settings;
            return builder;
        }

        public bool SettingsExist()
        {
            return _settings != null;
        }
    }
}