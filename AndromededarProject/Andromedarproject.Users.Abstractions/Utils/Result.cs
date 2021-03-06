﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.Users.Abstractions.Utils
{
    public class Result<T>
    {
        public bool Success { get; set; }

        public T Value {
            get => Success ? _value : throw new KeyNotFoundException();
            set => _value = value;
        }

        private T _value;
    }
}
