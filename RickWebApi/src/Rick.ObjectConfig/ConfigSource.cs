﻿using System;
using Rick.ObjectConfig.Abstraction;

namespace Rick.ObjectConfig
{
    public class ConfigSource : IConfigSource
    {
        protected string _Key;
        protected Func<object> _GetValue;

        public ConfigSource(string key, Func<object> getValue)
        {
            _Key = key;
            _GetValue = getValue;
        }

        public string Key
        {
            get
            {
                return _Key;
            }
        }

        public object GetValue()
        {
            return _GetValue();
        }
    }
}