﻿using System;
using DeepClone.Model;
using System.Collections.Generic;

namespace DeepClone.Template
{
    public class CloneTemplate : ICloneTemplate
    {


        private readonly HashSet<ICloneTemplate> _handlers;
        public CloneTemplate()
        {
            _handlers = new HashSet<ICloneTemplate>();
        }




        public bool MatchType(Type type)
        {
            throw new NotImplementedException();
        }




        /// <summary>
        /// 注册处理类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public CloneTemplate Register<T>() where T: ICloneTemplate,new()
        {
            _handlers.Add(new T());
            return this;
        }





        public Delegate TypeRouter(BuilderInfo info)
        {

            foreach (var item in _handlers)
            {
                return item.MatchType(info.DeclaringType)?  item.TypeRouter(info.DeclaringType) :  default;
            }
            return default;

        }
    }
}
