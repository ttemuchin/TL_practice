﻿namespace CarFactory.Models
{
    public interface ICar
    {
        string Name { get; }
        public float[] CalculatePrice();
        public string GetAllParams();

    }
}
