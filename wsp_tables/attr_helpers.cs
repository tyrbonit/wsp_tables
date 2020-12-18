using System;
using ExcelDna.Integration;

namespace wsp_tables
{
    class P_Attr : ExcelArgumentAttribute
    {
        public P_Attr()
        {
            this.Description = "Давление, кгс/см²";
            this.Name = "p";
        }
    }
    class PS_Attr : ExcelArgumentAttribute
    {
        public PS_Attr()
        {
            this.Description = "Давление насыщения, кгс/см²";
            this.Name = "ps";
        }
    }
    class T_Attr : ExcelArgumentAttribute
    {
        public T_Attr()
        {
            this.Description = "Температура, °C";
            this.Name = "t";
        }
    }
    class TS_Attr : ExcelArgumentAttribute
    {
        public TS_Attr()
        {
            this.Description = "Температура насыщения, °C";
            this.Name = "ts";
        }
    }
    class H_Attr : ExcelArgumentAttribute
    {
        public H_Attr()
        {
            this.Description = "Удельная энтальпия, ккал/кг";
            this.Name = "h";
        }
    }
    class HSW_Attr : ExcelArgumentAttribute
    {
        public HSW_Attr()
        {
            this.Description = "Удельная энтальпия кипящей воды, ккал/кг";
            this.Name = "hsw";
        }
    }
    class HSS_Attr : ExcelArgumentAttribute
    {
        public HSS_Attr()
        {
            this.Description = "Удельная энтальпия насыщенного пара, ккал/кг";
            this.Name = "hss";
        }
    }
    class S_Attr : ExcelArgumentAttribute
    {
        public S_Attr()
        {
            this.Description = "Удельная энтропия, ккал/кг°C";
            this.Name = "s";
        }
    }
    class SSW_Attr : ExcelArgumentAttribute
    {
        public SSW_Attr()
        {
            this.Description = "Удельная энтропия, ккал/кг°C";
            this.Name = "ssw";
        }
    }
    class SSS_Attr : ExcelArgumentAttribute
    {
        public SSS_Attr()
        {
            this.Description = "Удельная энтропия, ккал/кг°C";
            this.Name = "sss";
        }
    }
    class V_Attr : ExcelArgumentAttribute
    {
        public V_Attr()
        { 
            this.Description = "Удельный объем, м³/кг";
            this.Name = "v";
        }
    }
    class D_Attr : ExcelArgumentAttribute
    {
        public D_Attr()
        {
            this.Description = "Плотность, кг/м³";
            this.Name = "d";
        }
    }
    class CP_Attr : ExcelArgumentAttribute
    {
        public CP_Attr()
        {
            this.Description = "Изобарная теплоемкость, ккал/кг°C";
            this.Name = "Cp";
        }
    }
    class CV_Attr : ExcelArgumentAttribute
    {
        public CV_Attr()
        {
            this.Description = "Изохорная теплоемкость, ккал/кг°C";
            this.Name = "Cv";
        }
    }
    class X_Attr : ExcelArgumentAttribute
    {
        public X_Attr()
        {
            this.Description = "Степень сухости";
            this.Name = "x";
        }
    }
}
