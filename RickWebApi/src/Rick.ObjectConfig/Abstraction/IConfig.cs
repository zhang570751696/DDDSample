﻿namespace Rick.ObjectConfig.Abstraction
{
    public interface IConfig
    {
        IConfigSource GetConfigSource(string key);
    }
}