using System;
using ExcelDna.Integration;


namespace wsp_tables
{
    public static class wsp_tables
    {
        /*************************************************************************************************************/
        /**                     Water and steam properties according to IAPWS IF-97                                 **/
        /*************************************************************************************************************/

        /** *Contents.                              										                        **/
        /** *Units.                              										                        **/
        /** *1 Calling functions                                  								                    **/
        /** *1.1 Exposed functions                         												            **/
        /** *1.2 Temperature (T)                                                  								    **/
        /** *1.3 Pressure (p)                                                     								    **/
        /** *1.4 Enthalpy (h)                                                    								    **/
        /** *1.5 Specific Volume (v)                                              								    **/
        /** *1.6 Density (rho)                                                   								    **/
        /** *1.7 Specific entropy (s)                                            								    **/
        /** *1.8 Specific internal energy (u)                                    								    **/
        /** *1.9 Specific isobaric heat capacity (Cp)                            								    **/
        /** *1.10 Specific isochoric heat capacity (Cv)                                                     		**/
        /** *1.11 Speed of sound                                                								    **/
        /** *1.12 Viscosity                                                    								      	**/
        /** *1.13 Prandtl                                                     								     	**/
        /** *1.14 Kappa                                                   								       		**/
        /** *1.15 Surface tension                                            								        **/
        /** *1.16 Heat conductivity                                           								        **/
        /** *1.17 Vapour fraction                                             								        **/
        /** *1.18 Vapour Volume Fraction                                           								    **/
        /**                                                   								     					**/
        /** *2 IAPWS if 97 Calling functions                               								            **/
        /** *2.1 Functions for region 1                                    								            **/
        /** *2.2 Functions for region 2                                   								            **/
        /** *2.3 Functions for region 3                                     								        **/
        /** *2.4 Functions for region 4                                      								        **/
        /** *2.5 Functions for region 5                                      								        **/
        /**                                                  				 								    	**/
        /** *3 Region Selection                                              								        **/
        /** *3.1 Regions as a function of pT                                     								    **/
        /** *3.2 Regions as a function of ph                                       								    **/
        /** *3.3 Regions as a function of ps                                        								**/
        /** *3.4 Regions as a function of hs                                        								**/
        /** *3.5 Regions as a function of p and rho                                 								**/
        /**                                                    								     					**/
        /** 4 Region Borders                                              			 								**/
        /** 4.1 Boundary between region 1 and 3.                                    								**/
        /** 4.2 Region 3. pSat_h and wsp_PSS                                        								**/
        /** 4.3 Region boundary 1to3 and 3to2 as a functions of s                                 					**/
        /**                                                   								     					**/
        /** 5 Transport properties                                      								            **/
        /** 5.1 Viscosity (IAPWS formulation 1985)                           								        **/
        /** 5.2 Thermal Conductivity (IAPWS formulation 1985)                								        **/
        /** 5.3 Surface Tension                                                								        **/
        /***********************************************************************************************************/
        #region Units                                                                                      
        /***********************************************************************************************************/

        private static double toSIunit_p(double Ins) { return Ins * 98066.5 / 1000000; }

        private static double fromSIunit_p(double Ins) { return Ins / (98066.5 / 1000000); }

        private static double toSIunit_T(double Ins) { return Ins + 273.15; }

        private static double fromSIunit_T(double Ins) => Ins - (Ins == 0 ? 0 : 273.15);

        private static double toSIunit_h(double Ins) { return Ins * 4.1868; }

        private static double fromSIunit_h(double Ins) { return Ins / 4.1868; }

        private static double toSIunit_v(double Ins) { return Ins; }

        private static double fromSIunit_v(double Ins) { return Ins; }

        private static double toSIunit_d(double Ins) { return Ins; }

        private static double fromSIunit_d(double Ins) { return Ins; }

        private static double toSIunit_s(double Ins) { return Ins * 4.1868; }

        private static double fromSIunit_s(double Ins) { return Ins / 4.1868; }

        private static double toSIunit_u(double Ins) { return Ins * 4.1868; }

        private static double fromSIunit_u(double Ins) { return Ins / 4.1868; }

        private static double toSIunit_Cp(double Ins) { return Ins * 4.1868; }

        private static double fromSIunit_Cp(double Ins) { return Ins / 4.1868; }

        private static double toSIunit_Cv(double Ins) { return Ins * 4.1868; }

        private static double fromSIunit_Cv(double Ins) { return Ins / 4.1868; }

        private static double toSIunit_w(double Ins) { return Ins; }

        private static double fromSIunit_w(double Ins) { return Ins; }

        private static double toSIunit_tc(double Ins) { return Ins; }

        private static double fromSIunit_tc(double Ins) { return Ins; }

        private static double toSIunit_st(double Ins) { return Ins; }

        private static double fromSIunit_st(double Ins) { return Ins; }

        private static double toSIunit_x(double Ins) { return Ins; }

        private static double fromSIunit_x(double Ins) { return Ins; }

        private static double toSIunit_vx(double Ins) { return Ins; }

        private static double fromSIunit_vx(double Ins) { return Ins; }

        private static double toSIunit_my(double Ins) { return Ins; }

        private static double fromSIunit_my(double Ins) { return Ins; }
        #endregion

        /***********************************************************************************************************
        # *1 Calling functions                                                                                      *
        # ***********************************************************************************************************/

        #region *1.1 Exposed functions

        [ExcelFunction(Description = "Давление насыщения[кгс/см²] по температуре[°C]", Category = "WSP - Давление воды и пара")]
        public static double wsp_PST([T_Attr()]double T) => fromSIunit_p(_PST(toSIunit_T(T)));
   



        [ExcelFunction(Description = "Давление насыщения[кгс/см²] по энтропии[ккал/кг°C]", Category = "WSP - Давление воды и пара")]
        public static double wsp_PSS([S_Attr()]double s) => fromSIunit_p(_PSS(toSIunit_s(s)));




        [ExcelFunction(Description = "Давление насыщения[кгс/см²] по энтальпии[ккал/кг]", Category = "WSP - Давление воды и пара")]
        public static double wsp_PSH([H_Attr()]double h) => fromSIunit_p(_PSH(toSIunit_h(h)));




        [ExcelFunction(Description = "Давление[кгс/см²] по энтальпии[ккал/кг] и энтропии[ккал/кг°C]", Category = "WSP - Давление воды и пара")]
        public static double wsp_PHS([H_Attr()]double h, [S_Attr()]double s) => fromSIunit_p(_PHS(toSIunit_h(h), toSIunit_s(s)));










        [ExcelFunction(Description = "Температура насыщения[°C] по давлению[кгс/см²]", Category = "WSP - Температура воды и пара")]
        public static double wsp_TSP([PS_Attr()]double p) => fromSIunit_T(_TSP(toSIunit_p(p)));



        [ExcelFunction(Description = "Температура насыщения[°C] по энтропии[ккал/кг°C]", Category = "WSP - Температура воды и пара")]
        public static double wsp_TSS([S_Attr()]double s) => fromSIunit_T(_TSS(toSIunit_s(s)));



        [ExcelFunction(Description = "Температура[°C] по давлению[кгс/см²] и энтальпии[ккал/кг] ", Category = "WSP - Температура воды и пара")]
        public static double wsp_TPH([P_Attr()]double p, [H_Attr()]double h) => fromSIunit_T(_TPH(toSIunit_p(p), toSIunit_h(h)));



        [ExcelFunction(Description = "Температура[°C] по давлению[кгс/см²] и энтропии[ккал/кг°C]", Category = "WSP - Температура воды и пара")]
        public static double wsp_TPS([P_Attr()]double p, [S_Attr()]double s) => fromSIunit_T(_TPS(toSIunit_p(p), toSIunit_s(s)));



        [ExcelFunction(Description = "Температура[°C] по энтальпии[ккал/кг] и энтропии[ккал/кг°C]", Category = "WSP - Температура воды и пара")]
        public static double wsp_THS([H_Attr()]double h, [S_Attr()]double s) => fromSIunit_T(_THS(toSIunit_h(h), toSIunit_s(s)));



        [ExcelFunction(Description = "Удельная энтальпия сухого насыщенного пара[ккал/кг] по давлению[кгс/см²]", Category = "WSP - Энтальпия воды и пара")]
        public static double wsp_HSSP([PS_Attr()]double p) => fromSIunit_h(_HSSP(toSIunit_p(p)));



        [ExcelFunction(Description = "Удельная энтальпия кипящей воды[ккал/кг] по давлению[кгс/см²]", Category = "WSP - Энтальпия воды и пара")]
        public static double wsp_HSWP([PS_Attr()]double p) => fromSIunit_h(_HSWP(toSIunit_p(p)));



        [ExcelFunction(Description = "Удельная энтальпия[ккал/кг] сухого насыщенного пара по температуре[°C]", Category = "WSP - Энтальпия воды и пара")]
        public static double wsp_HSST([TS_Attr()]double T) => fromSIunit_h(_HSST(toSIunit_T(T)));



        [ExcelFunction(Description = "Удельная энтальпия[ккал/кг] кипящей воды по температуре[°C]", Category = "WSP - Энтальпия воды и пара")]
        public static double wsp_HSWT([TS_Attr()]double T) => fromSIunit_h(_HSWT(toSIunit_T(T)));



        [ExcelFunction(Description = "Удельная энтальпия[ккал/кг] по давлению[кгс/см²] и температуре[°C]", Category = "WSP - Энтальпия воды и пара")]
        public static double wsp_HPT([P_Attr()] double p, [T_Attr()] double T) => fromSIunit_h(_HPT(toSIunit_p(p), toSIunit_T(T)));



        [ExcelFunction(Description = "Удельная энтальпия[ккал/кг] по давлению[кгс/см²] и энтропии[ккал/кг°C]", Category = "WSP - Энтальпия воды и пара")]
        public static double wsp_HPS([P_Attr()]double p, [S_Attr()]double s) => fromSIunit_h(_HPS(toSIunit_p(p), toSIunit_s(s)));



        [ExcelFunction(Description = "Удельная энтальпия[ккал/кг] влажного пара по давлению[кгс/см²] и степени сухости", Category = "WSP - Энтальпия воды и пара")]
        public static double wsp_HSPX([P_Attr()]double p, [X_Attr()]double x) => fromSIunit_h(_HSPX(toSIunit_p(p), toSIunit_x(x)));



        [ExcelFunction(Description = "Удельная энтальпия[ккал/кг] влажного пара по температуре[°C] и степени сухости", Category = "WSP - Энтальпия воды и пара")]
        public static double wsp_HSTX([T_Attr()]double T, [X_Attr()]double x) => fromSIunit_h(_HSTX(toSIunit_T(T), toSIunit_x(x)));



        [ExcelFunction(Description = "Удельная энтальпия[ккал/кг] по давлению[кгс/см²] и плотности[кг/м³]", Category = "WSP - Энтальпия воды и пара")]
        public static double wsp_HPD([P_Attr()]double p, [D_Attr()]double rho) => fromSIunit_h(_HPD(toSIunit_p(p), toSIunit_d(rho)));



        [ExcelFunction(Description = "Удельный объем[м³/кг] сухого насыщенного пара по давлению[кгс/см²]", Category = "WSP - Удельный объем воды и пара")]
        public static double wsp_VSSP([P_Attr()]double p) => fromSIunit_v(_VSSP(toSIunit_p(p)));



        [ExcelFunction(Description = "Удельный объем[м³/кг] кипящей воды по давлению[кгс/см²]", Category = "WSP - Удельный объем воды и пара")]
        public static double wsp_VSWP([P_Attr()]double p) => fromSIunit_v(_VSWP(toSIunit_p(p)));



        [ExcelFunction(Description = "Удельный объем[м³/кг] сухого насыщенного пара по температуре[°C]", Category = "WSP - Удельный объем воды и пара")]
        public static double wsp_VSST([TS_Attr()]double T) => fromSIunit_v(_VSST(toSIunit_T(T)));



        [ExcelFunction(Description = "Удельный объем[м³/кг] кипящей воды по температуре[°C]", Category = "WSP - Удельный объем воды и пара")]
        public static double wsp_VSWT([TS_Attr()]double T) => fromSIunit_v(_VSWT(toSIunit_T(T)));



        [ExcelFunction(Description = "Удельный объем[м³/кг] по давлению[кгс/см²] и температуре[°C]", Category = "WSP - Удельный объем воды и пара")]
        public static double wsp_VPT([P_Attr()]double p, [T_Attr()]double T) => fromSIunit_v(_VPT(toSIunit_p(p), toSIunit_T(T)));



        [ExcelFunction(Description = "Удельный объем[м³/кг] по давлению[кгс/см²] и энтальпии[ккал/кг]", Category = "WSP - Удельный объем воды и пара")]
        public static double wsp_VPH([P_Attr()]double p, [H_Attr()]double h) => fromSIunit_v(_VPH(toSIunit_p(p), toSIunit_h(h)));



        [ExcelFunction(Description = "Удельный объем[м³/кг] по давлению[кгс/см²] и энтропии[ккал/кг°C]", Category = "WSP - Удельный объем воды и пара")]
        public static double wsp_VPS([P_Attr()]double p, [S_Attr()]double s) => fromSIunit_v(_VPS(toSIunit_p(p), toSIunit_s(s)));



        [ExcelFunction(Description = "Плотность[кг/м³] сухого насыщенного пара по давлению[кгс/см²]", Category = "WSP - Плотность воды и пара")]
        public static double wsp_DSSP([P_Attr()]double p) => fromSIunit_d(_DSSP(toSIunit_p(p)));



        [ExcelFunction(Description = "Плотность[кг/м³] кипящей воды по давлению[кгс/см²]", Category = "WSP - Плотность воды и пара")]
        public static double wsp_DSWP([P_Attr()]double p) => fromSIunit_d(_DSWP(toSIunit_p(p)));



        [ExcelFunction(Description = "Плотность[кг/м³] сухого насыщенного пара по температуре[°C]", Category = "WSP - Плотность воды и пара")]
        public static double wsp_DSST([T_Attr()]double T) => fromSIunit_d(_DSST(toSIunit_T(T)));



        [ExcelFunction(Description = "Плотность[кг/м³] кипящей воды по температуре[°C]", Category = "WSP - Плотность воды и пара")]
        public static double wsp_DSWT([T_Attr()]double T) => fromSIunit_d(_DSWT(toSIunit_T(T)));



        [ExcelFunction(Description = "Плотность[кг/м³] воды по давлению[кгс/см²] и температуре[°C]", Category = "WSP - Плотность воды и пара")]
        public static double wsp_DPT([P_Attr()]double p, [T_Attr()]double T) => fromSIunit_d(_DPT(toSIunit_p(p), toSIunit_T(T)));



        [ExcelFunction(Description = "Плотность[кг/м³] по давлению[кгс/см²] и энтальпии[ккал/кг]", Category = "WSP - Плотность воды и пара")]
        public static double wsp_DPH([P_Attr()]double p, [H_Attr()]double h) => fromSIunit_d(_DPH(toSIunit_p(p), toSIunit_h(h)));



        [ExcelFunction(Description = "Плотность[кг/м³] по давлению[кгс/см²] и энтропии[ккал/кг°C]", Category = "WSP - Плотность воды и пара")]
        public static double wsp_DPS([P_Attr()]double p, [S_Attr()]double s) => fromSIunit_d(_DPS(toSIunit_p(p), toSIunit_s(s)));



        [ExcelFunction(Description = "Удельная энтропия[ккал/кг°C] сухого насыщенного пара по давлению[кгс/см²]", Category = "WSP - Энтропия воды и пара")]
        public static double wsp_SSSP([P_Attr()]double p) => fromSIunit_s(_SSSP(toSIunit_p(p)));



        [ExcelFunction(Description = "Удельная энтропия[ккал/кг°C] кипящей воды по давлению[кгс/см²]", Category = "WSP - Энтропия воды и пара")]
        public static double wsp_SSWP([P_Attr()]double p) => fromSIunit_s(_SSWP(toSIunit_p(p)));



        [ExcelFunction(Description = "Удельная энтропия[ккал/кг°C] сухого насыщенного пара по температуре[°C]", Category = "WSP - Энтропия воды и пара")]
        public static double wsp_SSST([T_Attr()]double T) => fromSIunit_s(_SSST(toSIunit_T(T)));



        [ExcelFunction(Description = "Удельная энтропия[ккал/кг°C] кипящей воды по температуре[°C]", Category = "WSP - Энтропия воды и пара")]
        public static double wsp_SSWT([T_Attr()]double T) => fromSIunit_s(_SSWT(toSIunit_T(T)));



        [ExcelFunction(Description = "Удельная энтропия[ккал/кг°C] по давлению[кгс/см²] и температуре[°C]", Category = "WSP - Энтропия воды и пара")]
        public static double wsp_SPT([P_Attr()]double p, [T_Attr()]double T) => fromSIunit_s(_SPT(toSIunit_p(p), toSIunit_T(T)));



        [ExcelFunction(Description = "Удельная энтропия[ккал/кг°C] по давлению[кгс/см²] и энтальпии[ккал/кг]", Category = "WSP - Энтропия воды и пара")]
        public static double wsp_SPH([P_Attr()]double p, [H_Attr()]double h) => fromSIunit_s(_SPH(toSIunit_p(p), toSIunit_h(h)));



        [ExcelFunction(Description = "Удельная внутренняя энергия[ккал/кг] сухого насыщенного пара по давлению[кгс/см²]", Category = "WSP - Внутренняя энергия воды и пара")]
        public static double wsp_USSP([P_Attr()]double p) => fromSIunit_u(_USSP(toSIunit_p(p)));



        [ExcelFunction(Description = "Удельная внутренняя энергия[ккал/кг] кипящей воды по давлению[кгс/см²]", Category = "WSP - Внутренняя энергия воды и пара")]
        public static double wsp_USWP([P_Attr()]double p) => fromSIunit_u(_USWP(toSIunit_p(p)));



        [ExcelFunction(Description = "Удельная внутренняя энергия[ккал/кг] сухого насыщенного пара по температуре[°C]", Category = "WSP - Внутренняя энергия воды и пара")]
        public static double wsp_USST([T_Attr()]double T) => fromSIunit_u(_USST(toSIunit_T(T)));



        [ExcelFunction(Description = "Удельная внутренняя энергия[ккал/кг] кипящей воды по температуре[°C]", Category = "WSP - Внутренняя энергия воды и пара")]
        public static double wsp_USWT([T_Attr()]double T) => fromSIunit_u(_USWT(toSIunit_T(T)));



        [ExcelFunction(Description = "Удельная внутренняя энергия[ккал/кг] по давлению[кгс/см²] и температуре[°C]", Category = "WSP - Внутренняя энергия воды и пара")]
        public static double wsp_UPT([P_Attr()]double p, [T_Attr()]double T) => fromSIunit_u(_UPT(toSIunit_p(p), toSIunit_T(T)));



        [ExcelFunction(Description = "Удельная внутренняя энергия[ккал/кг] по давлению[кгс/см²] и энтальпии[ккал/кг]", Category = "WSP - Внутренняя энергия воды и пара")]
        public static double wsp_UPH([P_Attr()]double p, [H_Attr()]double h) => fromSIunit_u(_UPH(toSIunit_p(p), toSIunit_h(h)));



        [ExcelFunction(Description = "Удельная внутренняя энергия[ккал/кг] по давлению[кгс/см²] и энтропии[ккал/кг°C]", Category = "WSP - Внутренняя энергия воды и пара")]
        public static double wsp_UPS([P_Attr()]double p, [S_Attr()]double s) => fromSIunit_u(_UPS(toSIunit_p(p), toSIunit_s(s)));



        [ExcelFunction(Description = "Изобарная теплоемкость[ккал/кг°C] сухого насыщенного пара по давлению[кгс/см²]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CPSSP([P_Attr()]double p) => fromSIunit_Cp(_CPSSP(toSIunit_p(p)));



        [ExcelFunction(Description = "Изобарная теплоемкость[ккал/кг°C] кипящей воды по давлению[кгс/см²]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CPSWP([P_Attr()]double p) => fromSIunit_Cp(_CPSWP(toSIunit_p(p)));



        [ExcelFunction(Description = "Изобарная теплоемкость[ккал/кг°C] сухого насыщенного пара по температуре[°C]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CPSST([T_Attr()]double T) => fromSIunit_Cp(_CPSST(toSIunit_T(T)));



        [ExcelFunction(Description = "Изобарная теплоемкость[ккал/кг°C] кипящей воды по температуре[°C]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CPSWT([T_Attr()]double T) => fromSIunit_Cp(_CPSWT(toSIunit_T(T)));



        [ExcelFunction(Description = "Изобарная теплоемкость[ккал/кг°C] по давлению[кгс/см²] и температуре[°C]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CPPT([P_Attr()]double p, [T_Attr()]double T) => fromSIunit_Cp(_CPPT(toSIunit_p(p), toSIunit_T(T)));



        [ExcelFunction(Description = "Изобарная теплоемкость[ккал/кг°C] по давлению[кгс/см²] и энтальпии[ккал/кг]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CPPH([P_Attr()]double p, [H_Attr()]double h) => fromSIunit_Cp(_CPPH(toSIunit_p(p), toSIunit_h(h)));



        [ExcelFunction(Description = "Изобарная теплоемкость[ккал/кг°C] по давлению[кгс/см²] и энтропии[ккал/кг°C]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CPPS([P_Attr()]double p, [S_Attr()]double s) => fromSIunit_Cp(_CPPS(toSIunit_p(p), toSIunit_s(s)));



        [ExcelFunction(Description = "Изохорная теплоемкость[ккал/кг°C] сухого насыщенного пара по давлению[кгс/см²]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CVSSP([P_Attr()]double p) => fromSIunit_Cv(_CVSSP(toSIunit_p(p)));



        [ExcelFunction(Description = "Изохорная теплоемкость[ккал/кг°C] кипящей воды по давлению[кгс/см²]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CVSWP([P_Attr()]double p) => fromSIunit_Cv(_CVSWP(toSIunit_p(p)));



        [ExcelFunction(Description = "Изохорная теплоемкость[ккал/кг°C] сухого насыщенного пара по температуре[°C]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CVSST([T_Attr()]double T) => fromSIunit_Cv(_CVSST(toSIunit_T(T)));



        [ExcelFunction(Description = "Изохорная теплоемкость[ккал/кг°C] кипящей воды по температуре[°C]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CVSWT([T_Attr()]double T) => fromSIunit_Cv(_CVSWT(toSIunit_T(T)));



        [ExcelFunction(Description = "Изохорная теплоемкость[ккал/кг°C] по давлению[кгс/см²] и температуре[°C]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CVPT([P_Attr()]double p, [T_Attr()]double T) => fromSIunit_Cv(_CVPT(toSIunit_p(p), toSIunit_T(T)));



        [ExcelFunction(Description = "Изохорная теплоемкость[ккал/кг°C] по давлению[кгс/см²] и энтальпии[ккал/кг]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CVPH([P_Attr()]double p, [H_Attr()]double h) => fromSIunit_Cv(_CVPH(toSIunit_p(p), toSIunit_h(h)));



        [ExcelFunction(Description = "Изохорная теплоемкость[ккал/кг°C] по давлению[кгс/см²] и энтропии[ккал/кг°C]", Category = "WSP - Теплоемкость воды и пара")]
        public static double wsp_CVPS([P_Attr()]double p, [S_Attr()]double s) => fromSIunit_Cv(_CVPS(toSIunit_p(p), toSIunit_s(s)));





        [ExcelFunction(Description = "Скорость звука[м/с] в сухом насыщенном паре по давлению[кгс/см²]", Category = "WSP - Скорость звука в воде и паре")]
        public static double wsp_WSSP([P_Attr()]double p) => fromSIunit_w(_WSSP(toSIunit_p(p)));



        [ExcelFunction(Description = "Скорость звука[м/с] в кипящей воде по давлению[кгс/см²]", Category = "WSP - Скорость звука в воде и паре")]
        public static double wsp_WSWP([P_Attr()]double p) => fromSIunit_w(_WSWP(toSIunit_p(p)));



        [ExcelFunction(Description = "Скорость звука[м/с] в сухом насыщенном паре по температуре[°C]", Category = "WSP - Скорость звука в воде и паре")]
        public static double wsp_WSST([T_Attr()]double T) => fromSIunit_w(_WSST(toSIunit_T(T)));



        [ExcelFunction(Description = "Скорость звука[м/с] в кипящей воде по температуре[°C]", Category = "WSP - Скорость звука в воде и паре")]
        public static double wsp_WSWT([T_Attr()]double T) => fromSIunit_w(_WSWT(toSIunit_T(T)));



        [ExcelFunction(Description = "Скорость звука[м/с] по давлению[кгс/см²] и температуре[°C]", Category = "WSP - Скорость звука в воде и паре")]
        public static double wsp_WPT([P_Attr()]double p, [T_Attr()]double T) => fromSIunit_w(_WPT(toSIunit_p(p), toSIunit_T(T)));



        [ExcelFunction(Description = "Скорость звука[м/с] по давлению[кгс/см²] и энтальпии[ккал/кг]", Category = "WSP - Скорость звука в воде и паре")]
        public static double wsp_WPH([P_Attr()]double p, [H_Attr()]double h) => fromSIunit_w(_WPH(toSIunit_p(p), toSIunit_h(h)));



        [ExcelFunction(Description = "Скорость звука[м/с] по давлению[кгс/см²] и энтропии[ккал/кг°C]", Category = "WSP - Скорость звука в воде и паре")]
        public static double wsp_WPS([P_Attr()]double p, [S_Attr()]double s) => fromSIunit_w(_WPS(toSIunit_p(p), toSIunit_s(s)));




        [ExcelFunction(Description = "Степень сухости[-] по давлению[кгс/см²] и энтальпии[ккал/кг]", Category = "WSP - Степень сухости воды и пара")]
        public static double wsp_XPH([P_Attr()]double p, [H_Attr()]double h) => fromSIunit_x(_XPH(toSIunit_p(p), toSIunit_h(h)));



        [ExcelFunction(Description = "Степень сухости[-] по давлению[кгс/см²] и энтропии[ккал/кг]", Category = "WSP - Степень сухости воды и пара")]
        public static double wsp_XPS([P_Attr()]double p, [S_Attr()]double s) => fromSIunit_x(_XPS(toSIunit_p(p), toSIunit_s(s)));



        [ExcelFunction(Description = "Объемная степень сухости[-] по давлению[кгс/см²] и энтальпии[ккал/кг]", Category = "WSP - Степень сухости воды и пара")]
        public static double wsp_VXPH([P_Attr()]double p, [H_Attr()]double h) => fromSIunit_vx(_VXPH(toSIunit_p(p), toSIunit_h(h)));



        [ExcelFunction(Description = "Объемная степень сухости[-] по давлению[кгс/см²] и энтропии[ккал/кг]", Category = "WSP - Степень сухости воды и пара")]
        public static double wsp_VXPS([P_Attr()]double p, [S_Attr()]double s) => fromSIunit_vx(_VXPS(toSIunit_p(p), toSIunit_s(s)));







        [ExcelFunction(Description = "Динамическая вязкость[Па·с] по давлению[кгс/см²] и температуре[°C]", Category = "WSP - Вязкость воды и пара")]
        public static double wsp_DYNVISPT([P_Attr()]double p, [T_Attr()]double T) => fromSIunit_my(_DYNVISPT(toSIunit_p(p), toSIunit_T(T)));



        [ExcelFunction(Description = "Динамическая вязкость[Па·с] по давлению[кгс/см²] и энтальпии[ккал/кг]", Category = "WSP - Вязкость воды и пара")]
        public static double wsp_DYNVISPH([P_Attr()]double p, [H_Attr()]double h) => fromSIunit_my(_DYNVISPH(toSIunit_p(p), toSIunit_h(h)));



        [ExcelFunction(Description = "Динамическая вязкость[Па·с] по давлению[кгс/см²] и энтропии[ккал/кг°C]", Category = "WSP - Вязкость воды и пара")]
        public static double wsp_DYNVISPS([P_Attr()]double p, [S_Attr()]double s) => fromSIunit_my(_DYNVISPS(toSIunit_p(p), toSIunit_s(s)));








        [ExcelFunction(Description = "Поверхностное натяжение воды[н/м] по температуре[°C]", Category = "WSP - Поверхностное натяжение воды")]
        public static double wsp_SURFTENT([T_Attr()]double T) => fromSIunit_st(_SURFTENT(toSIunit_T(T)));
        [ExcelFunction(Description = "Поверхностное натяжение воды[н/м] по давлению[кгс/см²]", Category = "WSP - Поверхностное натяжение воды")]
        public static double wsp_SURFTENP([P_Attr()]double p) => fromSIunit_st(_SURFTENT(_TSP(toSIunit_p(p))));




        [ExcelFunction(Description = "Теплопроводность[Вт/(м·К)] сухого насыщенного пара по давлению[кгс/см²]", Category = "WSP - Теплопроводность воды и пара")]
        public static double wsp_THERMCONDSSP([P_Attr()]double p) => fromSIunit_tc(_THERMCONDSSP(toSIunit_p(p)));



        [ExcelFunction(Description = "Теплопроводность[Вт/(м·К)] кипящей воды по давлению[кгс/см²]", Category = "WSP - Теплопроводность воды и пара")]
        public static double wsp_THERMCONDSWP([P_Attr()]double p) => fromSIunit_tc(_THERMCONDSWP(toSIunit_p(p)));



        [ExcelFunction(Description = "Теплопроводность[Вт/(м·К)] сухого насыщенного пара по температуре[°C]", Category = "WSP - Теплопроводность воды и пара")]
        public static double wsp_THERMCONDSST([T_Attr()]double T) => fromSIunit_tc(_THERMCONDSST(toSIunit_T(T)));



        [ExcelFunction(Description = "Теплопроводность[Вт/(м·К)] кипящей воды по температуре[°C]", Category = "WSP - Теплопроводность воды и пара")]
        public static double wsp_THERMCONDSWT([T_Attr()]double T) => fromSIunit_tc(_THERMCONDSWT(toSIunit_T(T)));
        


        [ExcelFunction(Description = "Теплопроводность[Вт/(м·К)] по давлению[кгс/см²] и температуре[°C]", Category = "WSP - Теплопроводность воды и пара")]
        public static double wsp_THERMCONDPT([P_Attr()]double p, [T_Attr()]double T) => fromSIunit_tc(_THERMCONDPT(toSIunit_p(p), toSIunit_T(T)));



        [ExcelFunction(Description = "Теплопроводность[Вт/(м·К)] по давлению[кгс/см²] и энтальпии[ккал/кг]", Category = "WSP - Теплопроводность воды и пара")]
        public static double wsp_THERMCONDPH([P_Attr()]double p, [H_Attr()]double h) => fromSIunit_tc(_THERMCONDPH(toSIunit_p(p), toSIunit_h(h)));



        [ExcelFunction(Description = "Теплопроводность[Вт/(м·К)] по давлению[кгс/см²] и энтропии[ккал/кг°C]", Category = "WSP - Теплопроводность воды и пара")]
        public static double wsp_THERMCONDPS([P_Attr()]double p, [S_Attr()]double s) => fromSIunit_tc(_THERMCONDPS(toSIunit_p(p), toSIunit_s(s)));




        [ExcelFunction(Description = "Регион IAPWS-IF97 по давлению[кгс/см²] и энтропии[ккал/кг°C]", Category = "WSP - Регионы воды и пара")]
        public static int wsp_Region_PS([P_Attr()]double p, [S_Attr()]double s) => _Region_PS(toSIunit_p(p), toSIunit_s(s));

        [ExcelFunction(Description = "Регион IAPWS-IF97 по давлению[кгс/см²] и энтропии[ккал/кг°C]", Category = "WSP - Регионы воды и пара")]
        public static int wsp_Region_PS1([P_Attr()]double p, [S_Attr()]double s) => _Region_PS1(toSIunit_p(p), toSIunit_s(s));

        #endregion

        #region 1.1 constants
        // *1.1 Constants
        private const double R = 0.461526; // kJ/(kg K)
        private const double tc = 647.096; // K
        private const double pc = 22.064; // MPa
        private const double rhoc = 322.0; // kg/m3

        //# PMIN = _PST(273.15)   # Minimum pressure
        private const double PMIN = 0.000611212677444;
        //# PST_623 = _PST(623.15)  # P Saturation at 623.15 K, boundary region 1-3
        private const double PST_623 = 16.5291642526;

        #endregion
        /************************************************************************************************************/
        #region 1.2 Temperature
        private static double _TSP(double p)
        {
            if (0.000611657 < p && p < 22.06395) return _T4P(p);
            return 0;
        }

        


        private static double _TSS(double s)
        {
            if (-0.0001545495919 < s && s < 9.155759395)
            {
                double ps = _P4S(s);
                return _T4P(ps);
            }
            return 0;
        }
       


        private static double _TPH(double p, double h)
        {
            switch (_Region_PH(p, h))
            {
                case 1: return _T1PH(p, h);
                case 2: return _T2PH(p, h);
                case 3: return _T3PH(p, h);
                case 4: return _T4P(p);
                case 5: return _T5PH(p, h);
                default: return 0;
            };
        }
        


        private static double _TPS(double p, double s)
        {
            switch (_Region_PS(p, s))
            {
                case 1: return _T1PS(p, s);
                case 2: return _T2PS(p, s);
                case 3: return _T3PS(p, s);
                case 4: return _T4P(p);
                case 5: return _T5PS(p, s);
                default: return 0;
            };
        }
        

        private static double _THS(double h, double s)
        {
            switch (_Region_HS(h, s))
            {
                case 1: return _T1HS(h, s);
                case 2: return _T2HS(h, s);
                case 3: return _T3HS(h, s);
                case 4: return _T4HS(h, s);
                default: return 0;
            };
        }
       
        #endregion
        /***********************************************************************************************************/

        #region *1.3 Pressure (p)

        private static double _PST(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                return _PB4T(T);
            }

            return 0;
        }
        


        private static double _PSS(double s)
        {
            if (-0.0001545495919 < s && s < 9.155759395)
            {
                return _P4S(s);
            }
            return 0;
        }
        private static double _PSS1(double s)
        {
            // from python module
            /*"""Define the saturated line, P=f(s) for region 3

            Parameters
            ----------
            s : float
                Specific entropy, [kJ/kgK]

            Returns
            -------
            P : float
                Pressure, [MPa]

            Notes
            ------
            Raise :class:`NotImplementedError` if input isn't in limit:

                * s'(623.15K) ≤ s ≤ s''(623.15K)

            References
            ----------
            IAPWS, Revised Supplementary Release on Backward Equations for the
            Functions T(p,h), v(p,h) and T(p,s), v(p,s) for Region 3 of the IAPWS
            Industrial Formulation 1997 for the Thermodynamic Properties of Water and
            Steam, http://www.iapws.org/relguide/Supp-Tv%28ph,ps%293-2014.pdf, Eq 11

            Examples
            --------
            >>> _PSS(3.8)
            16.87755057
            >>> _PSS(5.2)
            16.68968482
            """*/

            //# Check input parameters
            double smin_Ps3 = 3.7782813395443475; // # _S1PT(PST_623, 623.15)  # _PropsR1_PT(PST_623, 623.15)["s"]
            double smax_Ps3 = 5.210887824931644; // # _S2PT(PST_623, 623.15)  # _PropsR2_PT(PST_623, 623.15)["s"]
            if (s < smin_Ps3 || s > smax_Ps3) return 0;

            double sigma = s / 5.2;
            int[] I = { 0, 1, 1, 4, 12, 12, 16, 24, 28, 32 };
            int[] J = { 0, 1, 32, 7, 4, 14, 36, 10, 0, 18 };
            double[] n = {0.639767553612785, -0.129727445396014e2, -0.224595125848403e16,
             0.177466741801846e7, 0.717079349571538e10, -0.378829107169011e18,
             -0.955586736431328e35, 0.187269814676188e24, 0.119254746466473e12,
             0.110649277244882e37};

            double suma = 0;
            for (int k = 0; k < 15; k++) { suma += n[k] * Math.Pow(sigma - 1.03, I[k]) * Math.Pow(sigma - 0.699, J[k]); }
            return 22 * suma;
        }


        private static double _PHS(double h, double s)
        {
            switch (_Region_HS(h, s))
            {
                case 1: return _P1HS(h, s);
                case 2: return _P2HS(h, s);
                case 3: return _P3HS(h, s);
                case 4: return _P4HS(h, s);
                default: return 0;
            };
        }

        #endregion
        /***********************************************************************************************************/
        #region *1.4 Enthalpy (h)

        private static double _HSSP(double p)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                return _H4SSP(p);
            }
            return 0;
        }
       


        private static double _HSWP(double p)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                return _H4SWP(p);
            }
            return 0;
        }
        


        private static double _HSST(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                return _H4SSP(_PB4T(T));
            }
            return 0;
        }
        


        private static double _HSWT(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                return _H4SWP(_PB4T(T));
            }
            return 0;
        }
       
        private static double _HPT(double p, double T)
        {
            switch (_Region_PT(p, T))
            {
                case 1: return _H1PT(p, T);
                case 2: return _H2PT(p, T);
                case 3: return _H3PT(p, T);
                case 5: return _H5PT(p, T);
                default: return 0;
            };
        }

        
        private static double _HPS(double p, double s)
        {
            switch (_Region_PS(p, s))
            {
                case 1: return _H1PS(p, s);
                case 2: return _H2PS(p, s);
                case 3: return _H3PS(p, s);
                case 4: return _H4PS(p, s);
                case 5: return _H5PS(p, s);
                default: return 0;
            };
        }
        
        private static double _HSPX(double p, double x)
        {
            if (x > 1 || x < 0 || p >= 22.064|| p < PMIN) return 0;
            if (x == 0) return _H4SWP(p);
            if (x == 1) return _H4SSP(p);
            double hL = _H4SWP(p);
            double hV = _H4SSP(p);
            return hL + x * (hV - hL);
        }
        

        private static double _HSTX(double T, double x)
        {
            if (x > 1 || x < 0 || T >= 647.096) return 0;
            double p = _PB4T(T);
            double hL = _H4SWP(p);
            double hV = _H4SSP(p);
            return hL + x * (hV - hL);
        }
        
        private static double _HPD(double p, double rho)
        {
            switch (_Region_PD(p, rho))
            {
                case 1: return _H1PD(p, rho);
                case 2: return _H2PD(p, rho);
                case 3: return _H3PD(p, rho);
                case 4: return _H4PD(p, rho);
                case 5: return _H5PD(p, rho);
                default: return 0;
            };
        }
        

  
        private static double _H1PS(double p, double s) => _H1PT(p, _T1PS(p, s));
        private static double _H2PS(double p, double s) => _H2PT(p, _T2PS(p, s));
        private static double _H3PS(double p, double s) => _H3PT(p, _T3PS(p, s));
        private static double _H4PS(double p, double s) => _H4SWP(p) + _X4PS(p, s) * (_H4SSP(p) - _H4SWP(p));
        private static double _H5PS(double p, double s) => _H5PT(p, _T5PS(p, s));


        private static double _H1PD(double p, double rho) => _H1PT(p, _T1PD(p, rho));
        private static double _H2PD(double p, double rho) => _H2PT(p, _T2PD(p, rho));
        private static double _H3PD(double p, double rho) => _H3PT(p, _T3PD(p, rho));//  # Проверить
        private static double _H5PD(double p, double rho) => _H5PT(p, _T5PD(p, rho));

        private static double _H4PD(double p, double rho)
        {
            double vV; double vL;
            if (p < 16.529) {
                vV = _V2PT(p, _T4P(p));
                vL = _V1PT(p, _T4P(p));
            }
            else {
                vV = _V3PH(p, _H4SSP(p));
                vL = _V3PH(p, _H4SWP(p));
            }
            double hV = _H4SSP(p);
            double hL = _H4SWP(p);
            double x = (1 / rho - vL) / (vV - vL);
            return (1 - x) * hL + x * hV;
        }
        #endregion
        /***********************************************************************************************************/
        #region *1.5 Specific Volume (v)

        private static double _VSSP(double p) {
            if (0.000611657 < p && p < 22.06395)
            {
                if (p < 16.529) return fromSIunit_v(_V2PT(p, _T4P(p)));
                else return _V3PH(p, _H4SSP(p));
            }
            return 0;
        }
       
        private static double _VSWP(double p)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                if (p < 16.529) return _V1PT(p, _T4P(p));
                else return _V3PH(p, _H4SWP(p));
            }
            return 0;
        }
        
        private static double _VSST(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                if (T <= 623.15) return _V2PT(_PB4T(T), T);
                else return _V3PH(_PB4T(T), _H4SSP(_PB4T(T)));
            }
            return 0;
        }

        
        private static double _VSWT(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                if (T <= 623.15) return _V1PT(_PB4T(T), T);
                else return _V3PH(_PB4T(T), _H4SWP(_PB4T(T)));
            }
            return 0;
        }

        
        private static double _VPT(double p, double T)
        {
            switch (_Region_PT(p, T))
            {
                case 1: return _V1PT(p, T);
                case 2: return _V2PT(p, T);
                case 3: return _V3PT(p, T);
                case 5: return _V5PT(p, T);
                default: return 0;
            };
        }
        
        private static double _VPH(double p, double h)
        {
            switch (_Region_PH(p, h))
            {
                case 1: return _V1PH(p, h);
                case 2: return _V2PH(p, h);
                case 3: return _V3PH(p, h);
                case 4: return _V4PH(p, h);
                case 5: return _V5PH(p, h);
                default: return 0;
            };
        }
        
        private static double _VPS(double p, double s)
        {
            switch (_Region_PS(p, s))
            {
                case 1: return _V1PS(p, s);
                case 2: return _V2PS(p, s);
                case 3: return _V3PS(p, s);
                case 4: return _V4PS(p, s);
                case 5: return _V5PS(p, s);
                default: return 0;
            };
        }
       

        private static double _V3PT(double p, double t) => _V3PH(p, _H3PT(p, t));


        private static double _V1PH(double p, double h) => _V1PT(p, _T1PH(p, h));
        private static double _V2PH(double p, double h) => _V2PT(p, _T2PH(p, h));
        private static double _V5PH(double p, double h) => _V5PT(p, _T5PH(p, h));


        private static double _V4PH(double p, double h)
        {
            double xs = _X4PH(p, h); double v4v; double v4L;
            if (p < 16.529) {
                v4v = _V2PT(p, _T4P(p));
                v4L = _V1PT(p, _T4P(p)); }
            else {
                v4v = _V3PH(p, _H4SSP(p));
                v4L = _V3PH(p, _H4SWP(p)); }
            return xs * v4v + (1 - xs) * v4L;
        }
        private static double _V1PS(double p, double s) => _V1PT(p, _T1PS(p, s));
        private static double _V2PS(double p, double s) => _V2PT(p, _T2PS(p, s));
        private static double _V5PS(double p, double s) => _V5PT(p, _T5PS(p, s));

        private static double _V4PS(double p, double s) {
            double xs = _X4PS(p, s); double v4v; double v4L;
            if (p < 16.529) {
                v4v = _V2PT(p, _T4P(p));
                v4L = _V1PT(p, _T4P(p));
            }
            else {
                v4v = _V3PH(p, _H4SSP(p));
                v4L = _V3PH(p, _H4SWP(p));
            };
            return xs * v4v + (1 - xs) * v4L;
        }
        #endregion



        /***********************************************************************************************************/
        #region *1.6 Density (rho)
        private static double _DSSP(double p) => 1 / _VSSP(p);
        
        private static double _DSWP(double p) => 1 / _VSWP(p);
       

        private static double _DSWT(double T) => 1 / _VSWT(T);
        

        private static double _DSST(double T) => 1 / _VSST(T);
        

        private static double _DPT(double p, double T) => 1 / _VPT(p, T);
        


        private static double _DPH(double p, double h) => 1 / _VPH(p, h);

        

        private static double _DPS(double p, double s) => 1 / _VPS(p, s);

       
        #endregion



        /***********************************************************************************************************/
        #region *1.7 Specific entropy (s)

        private static double _SSSP(double p)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                if (p < 16.529) return _S2PT(p, _T4P(p));
                else return _S3DT(1 / (_V3PH(p, _H4SSP(p))), _T4P(p));
            }
            return 0;
        }
        
        private static double _SSWP(double p)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                if (p < 16.529) return _S1PT(p, _T4P(p));
                else return _S3DT(1 / (_V3PH(p, _H4SWP(p))), _T4P(p));
            }
            return 0;
        }
        
        private static double _SSST(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                if (T <= 623.15) return _S2PT(_PB4T(T), T);
                else return _S3DT(1 / (_V3PH(_PB4T(T), _H4SSP(_PB4T(T)))), T);
            }
            return 0;
        }
        
        private static double _SSWT(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                if (T <= 623.15) return _S1PT(_PB4T(T), T);
                else return _S3DT(1 / (_V3PH(_PB4T(T), _H4SWP(_PB4T(T)))), T);
            }
            return 0;
        }
       
        private static double _SPT(double p, double T)
        {
            switch (_Region_PT(p, T))
            {
                case 1: return _S1PT(p, T);
                case 2: return _S2PT(p, T);
                case 3: return _S3PT(p, T);
                case 5: return _S5PT(p, T);
                default: return 0;
            };
        }
        
        
        private static double _SPH(double p, double h)
        {
            switch (_Region_PH(p, h))
            {
                case 1: return _S1PH(p, h);
                case 2: return _S2PH(p, h);
                case 3: return _S3PH(p, h);
                case 4: return _S4PH(p, h);
                case 5: return _S5PH(p, h);
                default: return 0;
            };
        }
       

        private static double _S3PT(double p, double T) => _S3DT(1.0 / _V3PH(p, _H3PT(p, T)), T);

        private static double _S1PH(double p, double h) => _S1PT(p, _T1PH(p, h));
        private static double _S2PH(double p, double h) => _S2PT(p, _T2PH(p, h));
        private static double _S3PH(double p, double h) => _S3DT(1.0 / _V3PH(p, h), _T3PH(p, h));
        private static double _S5PH(double p, double h) => _S5PT(p, _T5PH(p, h));


        private static double _S4PH(double p, double h) {
            double ts = _T4P(p);
            double xs = _X4PH(p, h);
            double s4v; double v4v; double s4L; double v4L;
            if (p < 16.529)
            {
                s4v = _S2PT(p, ts);
                s4L = _S1PT(p, ts);
            }
            else
            {
                v4v = _V3PH(p, _H4SSP(p));
                s4v = _S3DT(1 / v4v, ts);
                v4L = _V3PH(p, _H4SWP(p));
                s4L = _S3DT(1 / v4L, ts);
            }
            return (xs * s4v + (1 - xs) * s4L);
        }
        #endregion
        /***********************************************************************************************************/
        #region *1.8 Specific internal energy (u)
        
        private static double _USSP(double p)
        {
            if (0.000611657 < p && p < 22.06395) {
                if (p < 16.529) return _U2PT(p, _T4P(p));
                else return _U3DT(1 / _V3PH(p, _H4SSP(p)), _T4P(p));
            }
            return 0;
        }
        
        private static double _USWP(double p)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                if (p < 16.529) return _U1PT(p, _T4P(p));
                else return _U3DT(1 / (_V3PH(p, _H4SWP(p))), _T4P(p));
            }
            return 0;
        }
       
        private static double _USST(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                if (T <= 623.15) return _U2PT(_PB4T(T), T);
                else return _U3DT(1 / (_V3PH(_PB4T(T), _H4SSP(_PB4T(T)))), T);
            }
            return 0;
        }
       
       
        private static double _USWT(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                if (T <= 623.15) return _U1PT(_PB4T(T), T);
                else return _U3DT(1 / (_V3PH(_PB4T(T), _H4SWP(_PB4T(T)))), T);
            }
            return 0;
        }
        

        private static double _UPT(double p, double T) {
            switch (_Region_PT(p, T)) {
                case 1: return _U1PT(p, T);
                case 2: return _U2PT(p, T);
                case 3:
                    double hs = _H3PT(p, T);
                    double rhos = 1 / _V3PH(p, hs);
                    return _U3DT(rhos, T);
                case 4:
                    return 0;
                case 5:
                    return _U5PT(p, T);
                default: return 0;
            }
        }
       
        private static double _UPH(double p, double h)
        {
            switch (_Region_PH(p, h))
            {
                case 1: return _U1PT(p, _T1PH(p, h));
                case 2: return _U2PT(p, _T2PH(p, h));
                case 3: return _U3DT(1 / _V3PH(p, h), _T3PH(p, h));
                case 4:
                    double ts = _T4P(p);
                    double xs = _X4PH(p, h);
                    double u4v; double u4L;
                    if (p < 16.529){
                        u4v = _U2PT(p, ts);
                        u4L = _U1PT(p, ts);
                    }
                    else {
                        double v4v = _V3PH(p, _H4SSP(p));
                        u4v = _U3DT(1 / v4v, ts);
                        double v4L = _V3PH(p, _H4SWP(p));
                        u4L = _U3DT(1 / v4L, ts);
                    }
                    return (xs * u4v + (1 - xs) * u4L);
                case 5:
                    return _U5PT(p, _T5PH(p, h));
                default: return 0;
            }
        }
        
        private static double _UPS(double p, double s)
        {
            switch (_Region_PS(p, s))
            {
                case 1: return _U1PT(p, _T1PS(p, s));
                case 2: return _U2PT(p, _T2PS(p, s));
                case 3: return _U3DT(1 / _V3PS(p, s), _T3PS(p, s));
                case 4:
                    double uLp; double uVp;
                    if (p < 16.529) {
                        uLp = _U1PT(p, _T4P(p));
                        uVp = _U2PT(p, _T4P(p));
                    } else {
                        uLp = _U3DT(1 / (_V3PH(p, _H4SWP(p))), _T4P(p));
                        uVp = _U3DT(1 / (_V3PH(p, _H4SSP(p))), _T4P(p));
                    }
                    double xs = _X4PS(p, s);
                    return xs * uVp + (1 - xs) * uLp;
                case 5:
                    return _U5PT(p, _T5PS(p, s));
                default: return 0;
            }
        }
        

        #endregion
        /***********************************************************************************************************/
        #region *1.9 Specific isobaric heat capacity (Cp)

        private static double _CPSSP(double p)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                if (p < 16.529) return _CP2PT(p, _T4P(p));
                else return _CP3DT(1 / (_V3PH(p, _H4SSP(p))), _T4P(p));
            }
            return 0;
        }
       

        private static double _CPSWP(double p)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                if (p < 16.529) return _CP1PT(p, _T4P(p));
                else return _CP3DT(1 / (_V3PH(p, _H4SWP(p))), _T4P(p));
            }
            return 0;
        }
        
        private static double _CPSST(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                if (T <= 623.15) return _CP2PT(_PB4T(T), T);
                else return _CP3DT(1 / (_V3PH(_PB4T(T), _H4SSP(_PB4T(T)))), T);
            }
            return 0;
        }
        
        private static double _CPSWT(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                if (T <= 623.15) return _CP1PT(_PB4T(T), T);
                else return _CP3DT(1 / (_V3PH(_PB4T(T), _H4SWP(_PB4T(T)))), T);
            }
            return 0;
        }
       
        private static double _CPPT(double p, double T)
        {
            switch (_Region_PT(p, T))
            {
                case 1: return _CP1PT(p, T);
                case 2: return _CP2PT(p, T);
                case 3: return _CP3PT(p, T);
                case 5: return _CP5PT(p, T);
                default: return 0;
            };
        }
        
       private static double _CPPH(double p, double h)
        {
            switch (_Region_PH(p, h))
            {
                case 1: return _CP1PH(p, h);
                case 2: return _CP2PH(p, h);
                case 3: return _CP3PH(p, h);
                case 5: return _CP5PH(p, h);
                default: return 0;
            };
        }
        
        private static double _CPPS(double p, double s)
        {
            switch (_Region_PS(p, s))
            {
                case 1: return _CP1PS(p, s);
                case 2: return _CP2PS(p, s);
                case 3: return _CP3PS(p, s);
                case 5: return _CP5PS(p, s);
                default: return 0;
            };
        }
        
        private static double _CP3PT(double p, double T) => _CP3DT(1.0 / _V3PH(p, _H3PT(p, T)), T);
        private static double _CP1PH(double p, double h)=> _CP1PT(p, _T1PH(p, h));                                          private static double _CP2PH(double p, double h) => _CP2PT(p, _T2PH(p, h));
        private static double _CP3PH(double p, double h) => _CP3PT(p, _T3PH(p, h));
        private static double _CP5PH(double p, double h) => _CP5PT(p, _T5PH(p, h));


        private static double _CP1PS(double p, double s) => _CP1PT(p, _T1PS(p, s));
        private static double _CP2PS(double p, double s) => _CP2PT(p, _T2PS(p, s));
        private static double _CP3PS(double p, double s) => _CP3PT(p, _T3PS(p, s));
        private static double _CP5PS(double p, double s) => _CP2PT(p, _T5PS(p, s));
        #endregion


        /***********************************************************************************************************/


        #region *1.10 Specific isochoric heat capacity (Cv)

        private static double _CVSSP(double p)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                if (p < 16.529) return _CV2PT(p, _T4P(p));
                else return _CV3DT(1 / (_V3PH(p, _H4SSP(p))), _T4P(p));
            }
            return 0;
        }


        
        private static double _CVSWP(double p)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                if (p < 16.529) return _CV1PT(p, _T4P(p));
                else return _CV3DT(1 / (_V3PH(p, _H4SWP(p))), _T4P(p));
            }
            return 0;
        }
        
        private static double _CVSST(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                if (T <= 623.15) return _CV2PT(_PB4T(T), T);
                else return _CV3DT(1 / (_V3PH(_PB4T(T), _H4SSP(_PB4T(T)))), T);
            }
            return 0;
        }
        
        private static double _CVSWT(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                if (T <= 623.15) return _CV1PT(_PB4T(T), T);
                else return _CV3DT(1 / (_V3PH(_PB4T(T), _H4SWP(_PB4T(T)))), T);
            }
            return 0;
        }
        
        private static double _CVPT(double p, double T)
        {
            switch (_Region_PT(p, T))
            {
                case 1: return _CV1PT(p, T);
                case 2: return _CV2PT(p, T);
                case 3: return _CV3PT(p, T);
                case 5: return _CV5PT(p, T);
                default: return 0;
            };
        }
        
        private static double _CVPH(double p, double h)
        {
            switch (_Region_PH(p, h))
            {
                case 1: return _CV1PH(p, h);
                case 2: return _CV2PH(p, h);
                case 3: return _CV3PH(p, h);
                case 5: return _CV5PH(p, h);
                default: return 0;
            };
        }
        
        private static double _CVPS(double p, double s)
        {
            switch (_Region_PS(p, s))
            {
                case 1: return _CV1PS(p, s);
                case 2: return _CV2PS(p, s);
                case 3: return _CV3PS(p, s);
                case 5: return _CV5PS(p, s);
                default: return 0;
            };
        }
        


        private static double _CV3PT(double p, double t) => _CV3DT(1.0 / _V3PH(p, _H3PT(p, t)), t);


        private static double _CV1PH(double p, double h) => _CV1PT(p, _T1PH(p, h));
        private static double _CV2PH(double p, double h) => _CV2PT(p, _T2PH(p, h));
        private static double _CV3PH(double p, double h) => _CV3PT(p, _T3PH(p, h));
        private static double _CV5PH(double p, double h) => _CV5PT(p, _T5PH(p, h));


        private static double _CV1PS(double p, double s) => _CV1PT(p, _T1PS(p, s));
        private static double _CV2PS(double p, double s) => _CV2PT(p, _T2PS(p, s));
        private static double _CV3PS(double p, double s) => _CV3PT(p, _T3PS(p, s));
        private static double _CV5PS(double p, double s) => _CV5PT(p, _T5PS(p, s));

        #endregion



        /***********************************************************************************************************/
        #region *1.11 Speed of sound

        private static double _WSSP(double p)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                if (p < 16.529) return _W2PT(p, _T4P(p));
                else return _W3DT(1 / (_V3PH(p, _H4SSP(p))), _T4P(p));
            }
            return 0;
        }
        
        private static double _WSWP(double p)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                if (p < 16.529) return _W1PT(p, _T4P(p));
                else return _W3DT(1 / (_V3PH(p, _H4SWP(p))), _T4P(p));
            }
            return 0;
        }
        
        private static double _WSST(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                if (T <= 623.15) return _W2PT(_PB4T(T), T);
                else return _W3DT(1 / (_V3PH(_PB4T(T), _H4SSP(_PB4T(T)))), T);
            }
            return 0;
        }
       
        private static double _WSWT(double T)
        {
            if (273.15 < T && T < 647.096)
            {
                if (T <= 623.15) return _W1PT(_PB4T(T), T);
                else return _W3DT(1 / (_V3PH(_PB4T(T), _H4SWP(_PB4T(T)))), T);
            }
            return 0;
        }
        
        private static double _WPT(double p, double T)
        {
            switch (_Region_PT(p, T))
            {
                case 1: return _W1PT(p, T);
                case 2: return _W2PT(p, T);
                case 3: return _W3PT(p, T);
                case 5: return _W5PT(p, T);
                default: return 0;
            };
        }
        

        private static double _WPH(double p, double h)
        {
            switch (_Region_PH(p, h))
            {
                case 1: return _W1PH(p, h);
                case 2: return _W2PH(p, h);
                case 3: return _W3PH(p, h);
                case 5: return _W5PH(p, h);
                default: return 0;
            };
        }
       

        private static double _WPS(double p, double s)
        {
            switch (_Region_PS(p, s))
            {
                case 1: return _W1PS(p, s);
                case 2: return _W2PS(p, s);
                case 3: return _W3PS(p, s);
                case 5: return _W5PS(p, s);
                default: return 0;
            };
        }
        


        private static double _W3PT(double p, double T) => _W3DT(1.0 / _V3PH(p, _H3PT(p, T)), T);


        private static double _W1PH(double p, double h) => _W1PT(p, _T1PH(p, h));
        private static double _W2PH(double p, double h) => _W2PT(p, _T2PH(p, h));
        private static double _W3PH(double p, double h) => _W3DT(1.0/_V3PH(p, h), _T3PH(p, h));
        private static double _W5PH(double p, double h) => _W5PT(p, _T5PH(p, h));


        private static double _W1PS(double p, double s) => _W1PT(p, _T1PS(p, s));
        private static double _W2PS(double p, double s) => _W2PT(p, _T2PS(p, s));
        private static double _W3PS(double p, double s) => _W3DT(1.0 / _V3PS(p, s), _T3PS(p, s));
        private static double _W5PS(double p, double s) => _W5PT(p, _T5PS(p, s));

        #endregion
        /***********************************************************************************************************/
        #region *1.12 Viscosity

        private static double _DYNVISPT(double p, double T)
        {
            int r = _Region_PT(p, T);
            if (r == 0 || r == 4) return 0;
            return _DVPT(p, T);
        }

       


        private static double _DYNVISPH(double p, double h)
        {
            if (_Region_PH(p, h) == 0) return 0;
            return _DVPH(p, h);
        }
        

        private static double _DYNVISPS(double p, double s)
        {
            if (_Region_PS(p, s) == 0) return 0;
            return _DVPH(p, _HPS(p, s));
        }
        
        #endregion
        /***********************************************************************************************************/
        # region *1.13 Prandtl
            //TODO
        # endregion
        /***********************************************************************************************************/
        # region *1.14 Kappa
            //TODO
        # endregion
        /***********************************************************************************************************/
        #region *1.15 Surface tension

        
        #endregion
        
        
        
        /***********************************************************************************************************/
        #region *1.16 Thermal conductivity

        private static double _THERMCONDSSP(double p) => _THERMCONDPTD(p, _TSP(p), _DSSP(p));
        private static double _THERMCONDSWP(double p) => _THERMCONDPTD(p, _TSP(p), _DSWP(p));
        private static double _THERMCONDSST(double T) => _THERMCONDPTD(_PST(T), T,_DSST(T));
        private static double _THERMCONDSWT(double T) => _THERMCONDPTD(_PST(T), T, _DSWT(T));
        private static double _THERMCONDPT(double p, double T) => _THERMCONDPTD(p, T, _DPT(p, T));
        private static double _THERMCONDPH(double p, double h) => _THERMCONDPTD(p, _TPH(p, h), _DPH(p, h));
        private static double _THERMCONDPS(double p, double s) => _THERMCONDPTD(p, _TPS(p, s), _DPS(p, s));

        
        #endregion


        /***********************************************************************************************************/
        #region *1.17 Vapour fraction

        private static double _XPH(double p, double h)
        {
            if (0.000611657 < p && p < 22.06395) return _X4PH(p, h);
            return 0;
        }
        private static double _XPS(double p, double s)
        {
            if (0.000611657 < p && p < 22.06395) return _X4PS(p, s);
            return 0;
        }
        
        #endregion
        /***********************************************************************************************************/
        #region *1.18 Vapour Volume Fraction

        private static double _VXPH(double p, double h) {
            if (0.000611657 < p && p < 22.06395){
                double vL; double vV;
                if (p < 16.529){
                    vL = _V1PT(p, _T4P(p));
                    vV = _V2PT(p, _T4P(p));
                }
                else {
                    vL = _V3PH(p, _H4SWP(p));
                    vV = _V3PH(p, _H4SSP(p));
                }
                double xs = _X4PH(p, h);
                return xs * vV / (xs * vV + (1 - xs) * vL);
            }
            return 0;
        }
        
        private static double _VXPS(double p, double s)
        {
            if (0.000611657 < p && p < 22.06395)
            {
                double vL; double vV;
                if (p < 16.529)
                {
                    vL = _V1PT(p, _T4P(p));
                    vV = _V2PT(p, _T4P(p));
                }
                else {
                    vL = _V3PH(p, _H4SWP(p));
                    vV = _V3PH(p, _H4SSP(p));
                }
                double xs = _X4PS(p, s);
                return xs * vV / (xs * vV + (1 - xs) * vL);
            }
            return 0;
        }
        
        #endregion


        /***********************************************************************************************************/
        /**                             2 IAPWS if 97 Calling functions                                           **/
        /***********************************************************************************************************/

        #region *2.1 Functions for region 1

        private static double _V1PT(double p, double T) {
            //# Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //# 5 Equations for Region 1, Section. 5.1 Basic Equation
            //# Eqution 7, Table 3, Page 6
            int[] i1 = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 8, 8, 21, 23, 29, 30, 31, 32 };
            int[] J1 = {-2, -1, 0, 1, 2, 3, 4, 5, -9, -7, -1, 0, 1, 3, -3, 0, 1, 3, 17, -4, 0, 6, -5, -2, 10, -8, -11, -6, -29, -31,
                  -38, -39, -40, -41};
            double[] n1 = {
                0.14632971213167, -0.84548187169114, -3.756360367204, 3.3855169168385, -0.95791963387872, 0.15772038513228,
                -0.016616417199501, 0.00081214629983568, 0.00028319080123804, -0.00060706301565874, -0.018990068218419,
                -0.032529748770505, -0.021841717175414, -0.00005283835796993, -0.00047184321073267, -0.00030001780793026,
                0.000047661393906987, -0.0000044141845330846, -0.00000000000000072694996297594, -0.000031679644845054,
                -0.0000028270797985312, -0.00000000085205128120103, -0.0000022425281908, -0.00000065171222895601,
                -0.00000000000014341729937924, -0.00000040516996860117, -0.0000000012734301741641, -0.00000000017424871230634,
                -6.8762131295531E-19, 1.4478307828521E-20, 2.6335781662795E-23, -1.1947622640071E-23, 1.8228094581404E-24,
                -9.3537087292458E-26};
            double pi = p / 16.53;
            double tau = 1386 / T;
            double gamma_der_pi = 0;
            for (int I = 0; I < 34; I++) {
                gamma_der_pi = gamma_der_pi - n1[I] * i1[I] * Math.Pow(7.1 - pi, i1[I] - 1) * Math.Pow(tau - 1.222, J1[I]);
            }

            return R * T / p * pi * gamma_der_pi / 1000;
        }


        private static double _H1PT(double p, double T)
        {
            //# Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //# 5 Equations for Region 1, Section. 5.1 Basic Equation
            //# Eqution 7, Table 3, Page 6
            int[] i1 = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 8, 8, 21, 23, 29, 30, 31, 32 };
            int[] J1 = { -2, -1, 0, 1, 2, 3, 4, 5, -9, -7, -1, 0, 1, 3, -3, 0, 1, 3, 17, -4, 0, 6, -5, -2, 10, -8, -11, -6, -29, -31, -38, -39, -40, -41 };
            double[] n1 = { 0.14632971213167, -0.84548187169114, -3.756360367204, 3.3855169168385,
                -0.95791963387872, 0.15772038513228, -0.016616417199501, 0.00081214629983568,
                0.00028319080123804, -0.00060706301565874, -0.018990068218419, -0.032529748770505,
                -0.021841717175414, -0.00005283835796993, -0.00047184321073267, -0.00030001780793026,
                0.000047661393906987, -0.0000044141845330846, -0.00000000000000072694996297594,
                -0.000031679644845054, -0.0000028270797985312, -0.00000000085205128120103, -0.0000022425281908,
                -0.00000065171222895601, -0.00000000000014341729937924, -0.00000040516996860117, -0.0000000012734301741641,
                -0.00000000017424871230634, -6.8762131295531E-19, 1.4478307828521E-20, 2.6335781662795E-23,
                -1.1947622640071E-23, 1.8228094581404E-24, -9.3537087292458E-26 };
            double pi = p / 16.53;
            double tau = 1386 / T;
            double gamma_der_tau = 0;
            for (int I = 0; I < 34; I++) {
                gamma_der_tau = gamma_der_tau + (n1[I] * Math.Pow(7.1 - pi, i1[I]) * J1[I] * Math.Pow(tau - 1.222, J1[I] - 1));
            }
            return R * T * tau * gamma_der_tau;
        }


        private static double _U1PT(double p, double T) {
            //# Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //# 5 Equations for Region 1, Section. 5.1 Basic Equation
            //# Eqution 7, Table 3, Page 6
            int[] i1 = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 8, 8, 21, 23, 29, 30, 31, 32 };
            int[] J1 = { -2, -1, 0, 1, 2, 3, 4, 5, -9, -7, -1, 0, 1, 3, -3, 0, 1, 3, 17, -4, 0, 6, -5, -2, 10, -8, -11, -6, -29, -31, -38, -39, -40, -41 };
            double[] n1 = { 0.14632971213167, -0.84548187169114, -3.756360367204, 3.3855169168385,
                -0.95791963387872, 0.15772038513228, -0.016616417199501, 0.00081214629983568,
                0.00028319080123804, -0.00060706301565874, -0.018990068218419, -0.032529748770505,
                -0.021841717175414, -0.00005283835796993, -0.00047184321073267, -0.00030001780793026,
                0.000047661393906987, -0.0000044141845330846, -0.00000000000000072694996297594, -0.000031679644845054,
                -0.0000028270797985312, -0.00000000085205128120103, -0.0000022425281908, -0.00000065171222895601,
                -0.00000000000014341729937924, -0.00000040516996860117, -0.0000000012734301741641,
                -0.00000000017424871230634, -6.8762131295531E-19, 1.4478307828521E-20, 2.6335781662795E-23,
                -1.1947622640071E-23, 1.8228094581404E-24, -9.3537087292458E-26 };

            double pi = p / 16.53;
            double tau = 1386.0 / T;
            double gamma_der_tau = 0;
            double gamma_der_pi = 0;
            for (int I = 0; I < 34; I++) {
                gamma_der_pi = gamma_der_pi - n1[I] * i1[I] * Math.Pow(7.1 - pi, i1[I] - 1) * Math.Pow(tau - 1.222, J1[I]);
                gamma_der_tau = gamma_der_tau + (n1[I] * Math.Pow(7.1 - pi, i1[I]) * J1[I] * Math.Pow(tau - 1.222, J1[I] - 1));
            }

            return R * T * (tau * gamma_der_tau - pi * gamma_der_pi);
        }

        private static double _S1PT(double p, double T)
        {
            //# Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //# 5 Equations for Region 1, Section. 5.1 Basic Equation
            //# Eqution 7, Table 3, Page 6
            int[] i1 = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 8, 8, 21, 23, 29, 30, 31, 32 };
            int[] J1 = { -2, -1, 0, 1, 2, 3, 4, 5, -9, -7, -1, 0, 1, 3, -3, 0, 1, 3, 17, -4, 0, 6, -5, -2, 10, -8, -11, -6, -29, -31, -38, -39, -40, -41 };
            double[] n1 = { 0.14632971213167, -0.84548187169114, -3.756360367204, 3.3855169168385,
                -0.95791963387872, 0.15772038513228, -0.016616417199501, 0.00081214629983568,
                0.00028319080123804, -0.00060706301565874, -0.018990068218419, -0.032529748770505,
                -0.021841717175414, -0.00005283835796993, -0.00047184321073267, -0.00030001780793026,
                0.000047661393906987, -0.0000044141845330846, -0.00000000000000072694996297594,
                -0.000031679644845054, -0.0000028270797985312, -0.00000000085205128120103,
                -0.0000022425281908, -0.00000065171222895601, -0.00000000000014341729937924,
                -0.00000040516996860117, -0.0000000012734301741641, -0.00000000017424871230634,
                -6.8762131295531E-19, 1.4478307828521E-20, 2.6335781662795E-23, -1.1947622640071E-23,
                1.8228094581404E-24, -9.3537087292458E-26 };
            double pi = p / 16.53;
            double tau = 1386 / T;
            double gamma = 0;
            double gamma_der_tau = 0;
            for (int I = 0; I < 34; I++) {
                gamma_der_tau = gamma_der_tau + n1[I] * Math.Pow(7.1 - pi, i1[I]) * J1[I] * Math.Pow(tau - 1.222, J1[I] - 1);
                gamma = gamma + n1[I] * Math.Pow(7.1 - pi, i1[I]) * Math.Pow(tau - 1.222, J1[I]);
            }
            return R * tau * gamma_der_tau - R * gamma;
        }
        private static double _CP1PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 5 Equations for Region 1, Section. 5.1 Basic Equation
            // Eqution 7, Table 3, Page 6
            int[] i1 = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 8, 8, 21, 23, 29, 30, 31, 32 };
            int[] J1 = { -2, -1, 0, 1, 2, 3, 4, 5, -9, -7, -1, 0, 1, 3, -3, 0, 1, 3, 17, -4, 0, 6, -5, -2, 10, -8, -11, -6, -29, -31, -38, -39, -40, -41 };
            double[] n1 = { 0.14632971213167, -0.84548187169114, -3.756360367204, 3.3855169168385, -0.95791963387872, 0.15772038513228, -0.016616417199501, 0.00081214629983568, 0.00028319080123804, -0.00060706301565874, -0.018990068218419, -0.032529748770505, -0.021841717175414, -0.00005283835796993, -0.00047184321073267, -0.00030001780793026, 0.000047661393906987, -0.0000044141845330846, -0.00000000000000072694996297594, -0.000031679644845054, -0.0000028270797985312, -0.00000000085205128120103, -0.0000022425281908, -0.00000065171222895601, -0.00000000000014341729937924, -0.00000040516996860117, -0.0000000012734301741641, -0.00000000017424871230634, -6.8762131295531E-19, 1.4478307828521E-20, 2.6335781662795E-23, -1.1947622640071E-23, 1.8228094581404E-24, -9.3537087292458E-26 };

            double pi = p / 16.53;
            double tau = 1386 / T;
            double gamma_der_tautau = 0;
            for (int I = 0; I < 34; I++)
            {
                gamma_der_tautau = gamma_der_tautau + (n1[I] * Math.Pow(7.1 - pi, i1[I]) * J1[I] * (J1[I] - 1) * Math.Pow(tau - 1.222, J1[I] - 2));
            }
            return -R * Math.Pow(tau, 2) * gamma_der_tautau;
        }

        private static double _CV1PT(double p, double T) {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 5 Equations for Region 1, Section. 5.1 Basic Equation
            // Eqution 7, Table 3, Page 6
            int[] i1 = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 8, 8, 21, 23, 29, 30, 31, 32 };
            int[] J1 = { -2, -1, 0, 1, 2, 3, 4, 5, -9, -7, -1, 0, 1, 3, -3, 0, 1, 3, 17, -4, 0, 6, -5, -2, 10, -8, -11, -6, -29, -31, -38, -39, -40, -41 };
            double[] n1 = { 0.14632971213167, -0.84548187169114, -3.756360367204, 3.3855169168385, -0.95791963387872, 0.15772038513228, -0.016616417199501, 0.00081214629983568, 0.00028319080123804, -0.00060706301565874, -0.018990068218419, -0.032529748770505, -0.021841717175414, -0.00005283835796993, -0.00047184321073267, -0.00030001780793026, 0.000047661393906987, -0.0000044141845330846, -0.00000000000000072694996297594, -0.000031679644845054, -0.0000028270797985312, -0.00000000085205128120103, -0.0000022425281908, -0.00000065171222895601, -0.00000000000014341729937924, -0.00000040516996860117, -0.0000000012734301741641, -0.00000000017424871230634, -6.8762131295531E-19, 1.4478307828521E-20, 2.6335781662795E-23, -1.1947622640071E-23, 1.8228094581404E-24, -9.3537087292458E-26 };

            double pi = p / 16.53;
            double tau = 1386 / T;
            double gamma_der_pi = 0;
            double gamma_der_pipi = 0;
            double gamma_der_pitau = 0;
            double gamma_der_tautau = 0;
            for (int I = 0; I < 34; I++)
            {
                gamma_der_pi = gamma_der_pi - n1[I] * i1[I] * Math.Pow(7.1 - pi, i1[I] - 1) * Math.Pow(tau - 1.222, J1[I]);
                gamma_der_pipi = gamma_der_pipi + n1[I] * i1[I] * (i1[I] - 1) * Math.Pow(7.1 - pi, i1[I] - 2) * Math.Pow(tau - 1.222, J1[I]);
                gamma_der_pitau = gamma_der_pitau - n1[I] * i1[I] * Math.Pow(7.1 - pi, i1[I] - 1) * J1[I] * Math.Pow(tau - 1.222, J1[I] - 1);
                gamma_der_tautau = gamma_der_tautau + n1[I] * Math.Pow(7.1 - pi, i1[I]) * J1[I] * (J1[I] - 1) * Math.Pow(tau - 1.222, J1[I] - 2);
            }
            return R * (-Math.Pow(tau, 2) * gamma_der_tautau + Math.Pow(gamma_der_pi - tau * gamma_der_pitau, 2) / gamma_der_pipi);
        }
        private static double _W1PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 5 Equations for Region 1, Section. 5.1 Basic Equation
            // Eqution 7, Table 3, Page 6
            int[] i1 = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 8, 8, 21, 23, 29, 30, 31, 32 };
            int[] J1 = { -2, -1, 0, 1, 2, 3, 4, 5, -9, -7, -1, 0, 1, 3, -3, 0, 1, 3, 17, -4, 0, 6, -5, -2, 10, -8, -11, -6, -29, -31, -38, -39, -40, -41 };
            double[] n1 = { 0.14632971213167, -0.84548187169114, -3.756360367204, 3.3855169168385, -0.95791963387872, 0.15772038513228, -0.016616417199501, 0.00081214629983568, 0.00028319080123804, -0.00060706301565874, -0.018990068218419, -0.032529748770505, -0.021841717175414, -0.00005283835796993, -0.00047184321073267, -0.00030001780793026, 0.000047661393906987, -0.0000044141845330846, -0.00000000000000072694996297594, -0.000031679644845054, -0.0000028270797985312, -0.00000000085205128120103, -0.0000022425281908, -0.00000065171222895601, -0.00000000000014341729937924, -0.00000040516996860117, -0.0000000012734301741641, -0.00000000017424871230634, -6.8762131295531E-19, 1.4478307828521E-20, 2.6335781662795E-23, -1.1947622640071E-23, 1.8228094581404E-24, -9.3537087292458E-26 };

            double pi = p / 16.53;
            double tau = 1386 / T;
            double gamma_der_pi = 0;
            double gamma_der_pipi = 0;
            double gamma_der_pitau = 0;
            double gamma_der_tautau = 0;
            for (int I = 0; I < 34; I++)
            {
                gamma_der_pi = gamma_der_pi - n1[I] * i1[I] * Math.Pow(7.1 - pi, i1[I] - 1) * Math.Pow(tau - 1.222, J1[I]);
                gamma_der_pipi = gamma_der_pipi + n1[I] * i1[I] * (i1[I] - 1) * Math.Pow(7.1 - pi, i1[I] - 2) * Math.Pow(tau - 1.222, J1[I]);
                gamma_der_pitau = gamma_der_pitau - n1[I] * i1[I] * Math.Pow(7.1 - pi, i1[I] - 1) * J1[I] * Math.Pow(tau - 1.222, J1[I] - 1);
                gamma_der_tautau = gamma_der_tautau + n1[I] * Math.Pow(7.1 - pi, i1[I]) * J1[I] * (J1[I] - 1) * Math.Pow(tau - 1.222, J1[I] - 2);
            }
            return Math.Sqrt(1000 * R * T * Math.Pow(gamma_der_pi, 2) / (Math.Pow(gamma_der_pi - tau * gamma_der_pitau, 2) / (Math.Pow(tau, 2) * gamma_der_tautau) - gamma_der_pipi));
        }
        private static double _T1PH(double p, double h) {
            //# Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //# 5 Equations for Region 1, Section. 5.1 Basic Equation, 5.2.1 The Backward Equation T ( p,h )
            //# Eqution 11, Table 6, Page 10
            int[] i1 = { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 3, 4, 5, 6 };
            int[] J1 = { 0, 1, 2, 6, 22, 32, 0, 1, 2, 3, 4, 10, 32, 10, 32, 10, 32, 32, 32, 32 };
            double[] n1 = { -238.72489924521, 404.21188637945, 113.49746881718, -5.8457616048039,
                -0.0001528548241314, -0.0000010866707695377, -13.391744872602, 43.211039183559,
                -54.010067170506, 30.535892203916, -6.5964749423638, 0.0093965400878363,
                0.0000001157364750534, -0.000025858641282073, -0.0000000040644363084799,
                0.000000066456186191635, 0.000000000080670734103027, -0.00000000000093477771213947,
                0.0000000000000058265442020601, -1.5020185953503E-17};
            double pi = p / 1;
            double eta = h / 2500;
            double T = 0;
            for (int I = 0; I < 20; I++) {
                T = T + n1[I] * Math.Pow(pi, i1[I]) * Math.Pow(eta + 1, J1[I]);
            }
            return T;
        }


        private static double _T1HS(double h, double s) => _T1PH(_P1HS(h, s), h);

        private static double _T1PS(double p, double s) {
            //Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //5 Equations for Region 1, Section. 5.1 Basic Equation, 5.2.2 The Backward Equation T(p, s)
            //Eqution 13, Table 8, Page 11
            int[] i1 = { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 4 };
            int[] J1 = { 0, 1, 2, 3, 11, 31, 0, 1, 2, 3, 12, 31, 0, 1, 2, 9, 31, 10, 32, 32};
            double[] n1 = { 174.78268058307, 34.806930892873, 6.5292584978455, 0.33039981775489,
                -0.00000019281382923196, -2.4909197244573E-23, -0.26107636489332,
                0.22592965981586, -0.064256463395226, 0.0078876289270526, 0.00000000035672110607366,
                1.7332496994895E-24, 0.00056608900654837, -0.00032635483139717, 0.000044778286690632,
                -0.00000000051322156908507, -4.2522657042207E-26, 0.00000000000026400441360689,
                7.8124600459723E-29, -3.0732199903668E-31 };
            double pi = p / 1;
            double Sigma = s / 1;
            double T = 0;
            for (int I = 0; I < 20; I++) T += n1[I] * Math.Pow(pi, i1[I]) * Math.Pow(Sigma + 2, J1[I]);
            return T;
        }

        private static double _P1HS(double h, double s) {
            //Supplementary Release on Backward Equations for Pressure as a Function of Enthalpy and Entropy p(h,s)
            // to the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam
            //5 Backward Equation p(h, s) for Region 1
            // Eqution 1, Table 2, Page 5

            int[] i1 = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 3, 4, 4, 5 };
            int[] J1 = { 0, 1, 2, 4, 5, 6, 8, 14, 0, 1, 4, 6, 0, 1, 10, 4, 1, 4, 0 };
            double[] n1 = { -0.691997014660582, -18.361254878756, -9.28332409297335,
                65.9639569909906, -16.2060388912024, 450.620017338667, 854.68067822417,
                6075.23214001162, 32.6487682621856, -26.9408844582931, -319.9478483343,
                -928.35430704332, 30.3634537455249, -65.0540422444146, -4309.9131651613,
                -747.512324096068, 730.000345529245, 1142.84032569021, -436.407041874559 };
            double eta = h / 3400;
            double Sigma = s / 7.6;
            double p = 0;
            for (int I = 0; I < 19; I++) p += n1[I] * Math.Pow(eta + 0.05, i1[I]) * Math.Pow(Sigma + 0.05, J1[I]);
            return p * 100;
        }


        private static double _T1PD(double p, double rho) {
            //# Solve by iteration. Observe that fo low temperatures this equation has 2 solutions.
            //# Solve with half interval method
            double Low_Bound = 273.15;
            double High_Bound = _T4P(p);
            while (true) {
                double ts = (Low_Bound + High_Bound) / 2;
                double rhos = 1.0 / _V1PT(p, ts);
                if (Math.Abs(rho - rhos) < 0.00001) return ts;
                if (rhos < rho) High_Bound = ts;
                else Low_Bound = ts;
            }
        }

        #endregion
        // # ***********************************************************************************************************
        #region *2.2 Functions for region 2

        private static double _V2PT(double p, double T) {
            // Release on the IAPWS Industrial Formulation 1997 for 
            // the Thermodynamic Properties of Water and Steam, September 1997
            // 6 Equations for Region 2, Section. 6.1 Basic Equation
            // Table 11 and 12, Page 14 and 15
            // >>> _V2PT(30, 700)
            // 0.005429466194617729

            int[] Ir = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7,
                  7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24};
            int[] Jr = { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0,
                          11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58};
            double[] nr = {-0.0017731742473213, -0.017834862292358, -0.045996013696365, -0.057581259083432,
                          -0.05032527872793, -0.000033032641670203, -0.00018948987516315, -0.0039392777243355,
                          -0.043797295650573, -0.000026674547914087, 0.000000020481737692309, 0.00000043870667284435,
                          -0.00003227767723857, -0.0015033924542148, -0.040668253562649, -0.00000000078847309559367,
                          0.000000012790717852285, 0.00000048225372718507, 0.0000022922076337661, -0.000000000016714766451061,
                          -0.0021171472321355, -23.895741934104, -5.905956432427E-18, -0.0000012621808899101,
                          -0.038946842435739, 0.000000000011256211360459, -8.2311340897998, 0.000000019809712802088,
                          1.0406965210174E-19, -0.00000000000010234747095929, -0.0000000010018179379511, -0.000000000080882908646985,
                          0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 0.00000000000030629316876232,
                          -0.0000042002467698208, -5.9056029685639E-26, 0.0000037826947613457,
                          -0.0000000000000012768608934681, 7.3087610595061E-29, 5.5414715350778E-17, -0.0000009436970724121};

            double pi = p; ;
            double tau = 540.0 / T;
            double g0_pi = 1.0 / pi;
            double gr_pi = 0;
            for (int I = 0; I < 43; I++) gr_pi += nr[I] * Ir[I] * Math.Pow(pi, Ir[I] - 1) * Math.Pow(tau - 0.5, Jr[I]);

            return R * T / p * pi * (g0_pi + gr_pi) / 1000;
        }

        private static double _H2PT(double p, double T) {
            // Release on the IAPWS Industrial Formulation 1997 for
            // the Thermodynamic Properties of Water and Steam, September 1997
            // 6 Equations for Region 2, Section. 6.1 Basic Equation
            // Table 11 and 12, Page 14 and 15

            int[] J0 = { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            double[] n0 = { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455,
                -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            int[] Ir = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6,
                6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            int[] Jr = { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2,
                3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            double[] nr = { -0.0017731742473213, -0.017834862292358, -0.045996013696365,
                -0.057581259083432, -0.05032527872793, -0.000033032641670203, -0.00018948987516315,
                -0.0039392777243355, -0.043797295650573, -0.000026674547914087, 0.000000020481737692309,
                0.00000043870667284435, -0.00003227767723857, -0.0015033924542148, -0.040668253562649,
                -0.00000000078847309559367, 0.000000012790717852285, 0.00000048225372718507, 0.0000022922076337661,
                -0.000000000016714766451061, -0.0021171472321355, -23.895741934104, -5.905956432427E-18,
                -0.0000012621808899101, -0.038946842435739, 0.000000000011256211360459, -8.2311340897998,
                0.000000019809712802088, 1.0406965210174E-19, -0.00000000000010234747095929,
                -0.0000000010018179379511, -0.000000000080882908646985, 0.10693031879409, -0.33662250574171,
                8.9185845355421E-25, 0.00000000000030629316876232, -0.0000042002467698208, -5.9056029685639E-26,
                0.0000037826947613457, -0.0000000000000012768608934681, 7.3087610595061E-29, 5.5414715350778E-17,
                -0.0000009436970724121 };

            double pi = p;
            double tau = 540 / T;
            double g0_tau = 0;
            for (int I = 0; I < 9; I++) g0_tau += n0[I] * J0[I] * Math.Pow(tau, J0[I] - 1);

            double gr_tau = 0;
            for (int I = 0; I < 43; I++) gr_tau += nr[I] * Math.Pow(pi, Ir[I]) * Jr[I] * Math.Pow(tau - 0.5, Jr[I] - 1);

            return R * T * tau * (g0_tau + gr_tau);
        }
        private static double _U2PT(double p, double T)
        {
            /*Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            6 Equations for Region 2, Section. 6.1 Basic Equation
            Table 11 and 12, Page 14 and 15*/
            int[] J0 = { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            double[] n0 = { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            int[] Ir = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            int[] Jr = { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            double[] nr = { -0.0017731742473213, -0.017834862292358, -0.045996013696365, -0.057581259083432, -0.05032527872793, -0.000033032641670203, -0.00018948987516315, -0.0039392777243355, -0.043797295650573, -0.000026674547914087, 0.000000020481737692309, 0.00000043870667284435, -0.00003227767723857, -0.0015033924542148, -0.040668253562649, -0.00000000078847309559367, 0.000000012790717852285, 0.00000048225372718507, 0.0000022922076337661, -0.000000000016714766451061, -0.0021171472321355, -23.895741934104, -5.905956432427E-18, -0.0000012621808899101, -0.038946842435739, 0.000000000011256211360459, -8.2311340897998, 0.000000019809712802088, 1.0406965210174E-19, -0.00000000000010234747095929, -0.0000000010018179379511, -0.000000000080882908646985, 0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 0.00000000000030629316876232, -0.0000042002467698208, -5.9056029685639E-26, 0.0000037826947613457, -0.0000000000000012768608934681, 7.3087610595061E-29, 5.5414715350778E-17, -0.0000009436970724121 };

            double pi = p;
            double tau = 540.0 / T;
            double g0_pi = 1.0 / pi;
            double g0_tau = 0;
            for (int I = 0; I < 9; I++) g0_tau = g0_tau + n0[I] * J0[I] * Math.Pow(tau, J0[I] - 1);
            double gr_pi = 0;
            double gr_tau = 0;
            for (int I = 0; I < 43; I++)
            {
                gr_pi = gr_pi + nr[I] * Ir[I] * Math.Pow(pi, Ir[I] - 1) * Math.Pow(tau - 0.5, Jr[I]);
                gr_tau = gr_tau + nr[I] * Math.Pow(pi, Ir[I]) * Jr[I] * Math.Pow(tau - 0.5, Jr[I] - 1);
            }
            return R * T * (tau * (g0_tau + gr_tau) - pi * (g0_pi + gr_pi));

        }
        private static double _S2PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 6 Equations for Region 2, Section. 6.1 Basic Equation
            // Table 11 and 12, Page 14 and 15
            int[] J0 = { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            double[] n0 = { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            int[] Ir = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            int[] Jr = { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            double[] nr = { -0.0017731742473213, -0.017834862292358, -0.045996013696365, -0.057581259083432, -0.05032527872793, -0.000033032641670203, -0.00018948987516315, -0.0039392777243355, -0.043797295650573, -0.000026674547914087, 0.000000020481737692309, 0.00000043870667284435, -0.00003227767723857, -0.0015033924542148, -0.040668253562649, -0.00000000078847309559367, 0.000000012790717852285, 0.00000048225372718507, 0.0000022922076337661, -0.000000000016714766451061, -0.0021171472321355, -23.895741934104, -5.905956432427E-18, -0.0000012621808899101, -0.038946842435739, 0.000000000011256211360459, -8.2311340897998, 0.000000019809712802088, 1.0406965210174E-19, -0.00000000000010234747095929, -0.0000000010018179379511, -0.000000000080882908646985, 0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 0.00000000000030629316876232, -0.0000042002467698208, -5.9056029685639E-26, 0.0000037826947613457, -0.0000000000000012768608934681, 7.3087610595061E-29, 5.5414715350778E-17, -0.0000009436970724121 };

            double pi = p;
            double tau = 540 / T;
            double G0 = Math.Log(pi);
            double g0_tau = 0;
            for (int I = 0; I < 9; I++)
            {
                G0 = G0 + n0[I] * Math.Pow(tau, J0[I]);
                g0_tau = g0_tau + n0[I] * J0[I] * Math.Pow(tau, J0[I] - 1);
            }
            double gr = 0;
            double gr_tau = 0;
            for (int I = 0; I < 43; I++)
            {
                gr += nr[I] * Math.Pow(pi, Ir[I]) * Math.Pow(tau - 0.5, Jr[I]);
                gr_tau += nr[I] * Math.Pow(pi, Ir[I]) * Jr[I] * Math.Pow(tau - 0.5, Jr[I] - 1);
            }
            return R * (tau * (g0_tau + gr_tau) - (G0 + gr));
        }
        private static double _CP2PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 6 Equations for Region 2, Section. 6.1 Basic Equation
            // Table 11 and 12, Page 14 and 15
            int[] J0 = { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            double[] n0 = { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            int[] Ir = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            int[] Jr = { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            double[] nr = { -0.0017731742473213, -0.017834862292358, -0.045996013696365, -0.057581259083432, -0.05032527872793, -0.000033032641670203, -0.00018948987516315, -0.0039392777243355, -0.043797295650573, -0.000026674547914087, 0.000000020481737692309, 0.00000043870667284435, -0.00003227767723857, -0.0015033924542148, -0.040668253562649, -0.00000000078847309559367, 0.000000012790717852285, 0.00000048225372718507, 0.0000022922076337661, -0.000000000016714766451061, -0.0021171472321355, -23.895741934104, -5.905956432427E-18, -0.0000012621808899101, -0.038946842435739, 0.000000000011256211360459, -8.2311340897998, 0.000000019809712802088, 1.0406965210174E-19, -0.00000000000010234747095929, -0.0000000010018179379511, -0.000000000080882908646985, 0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 0.00000000000030629316876232, -0.0000042002467698208, -5.9056029685639E-26, 0.0000037826947613457, -0.0000000000000012768608934681, 7.3087610595061E-29, 5.5414715350778E-17, -0.0000009436970724121 };

            double pi = p;
            double tau = 540 / T;
            double g0_tautau = 0;
            for (int I = 0; I < 9; I++)
            {
                g0_tautau = g0_tautau + n0[I] * J0[I] * (J0[I] - 1) * Math.Pow(tau, J0[I] - 2);
            }
            double gr_tautau = 0;
            for (int I = 0; I < 43; I++)
            {
                gr_tautau = gr_tautau + nr[I] * Math.Pow(pi, Ir[I]) * Jr[I] * (Jr[I] - 1) * Math.Pow(tau - 0.5, Jr[I] - 2);
            }
            return -R * Math.Pow(tau, 2) * (g0_tautau + gr_tautau);

        }
        private static double _CV2PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 6 Equations for Region 2, Section. 6.1 Basic Equation
            // Table 11 and 12, Page 14 and 15
            int[] J0 = { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            double[] n0 = { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            int[] Ir = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            int[] Jr = { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            double[] nr = { -0.0017731742473213, -0.017834862292358, -0.045996013696365, -0.057581259083432, -0.05032527872793, -0.000033032641670203, -0.00018948987516315, -0.0039392777243355, -0.043797295650573, -0.000026674547914087, 0.000000020481737692309, 0.00000043870667284435, -0.00003227767723857, -0.0015033924542148, -0.040668253562649, -0.00000000078847309559367, 0.000000012790717852285, 0.00000048225372718507, 0.0000022922076337661, -0.000000000016714766451061, -0.0021171472321355, -23.895741934104, -5.905956432427E-18, -0.0000012621808899101, -0.038946842435739, 0.000000000011256211360459, -8.2311340897998, 0.000000019809712802088, 1.0406965210174E-19, -0.00000000000010234747095929, -0.0000000010018179379511, -0.000000000080882908646985, 0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 0.00000000000030629316876232, -0.0000042002467698208, -5.9056029685639E-26, 0.0000037826947613457, -0.0000000000000012768608934681, 7.3087610595061E-29, 5.5414715350778E-17, -0.0000009436970724121 };
            double pi = p;
            double tau = 540 / T;
            double g0_tautau = 0;
            for (int I = 0; I < 9; I++) g0_tautau = g0_tautau + n0[I] * J0[I] * (J0[I] - 1) * Math.Pow(tau, J0[I] - 2);
            double gr_pi = 0;
            double gr_pitau = 0;
            double gr_pipi = 0;
            double gr_tautau = 0;
            for (int I = 0; I < 43; I++)
            {
                gr_pi = gr_pi + nr[I] * Ir[I] * Math.Pow(pi, Ir[I] - 1) * Math.Pow(tau - 0.5, Jr[I]);
                gr_pipi = gr_pipi + nr[I] * Ir[I] * (Ir[I] - 1) * Math.Pow(pi, Ir[I] - 2) * Math.Pow(tau - 0.5, Jr[I]);
                gr_pitau = gr_pitau + nr[I] * Ir[I] * Math.Pow(pi, Ir[I] - 1) * Jr[I] * Math.Pow(tau - 0.5, Jr[I] - 1);
                gr_tautau = gr_tautau + nr[I] * Math.Pow(pi, Ir[I]) * Jr[I] * (Jr[I] - 1) * Math.Pow(tau - 0.5, Jr[I] - 2);
            }
            return R * (-Math.Pow(tau, 2) * (g0_tautau + gr_tautau) - Math.Pow(1 + pi * gr_pi - tau * pi * gr_pitau, 2) / (1 - Math.Pow(pi, 2) * gr_pipi));

        }
        private static double _W2PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 6 Equations for Region 2, Section. 6.1 Basic Equation
            // Table 11 and 12, Page 14 and 15
            int[] J0 = { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            double[] n0 = { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            int[] Ir = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            int[] Jr = { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            double[] nr = { -0.0017731742473213, -0.017834862292358, -0.045996013696365, -0.057581259083432, -0.05032527872793, -0.000033032641670203, -0.00018948987516315, -0.0039392777243355, -0.043797295650573, -0.000026674547914087, 0.000000020481737692309, 0.00000043870667284435, -0.00003227767723857, -0.0015033924542148, -0.040668253562649, -0.00000000078847309559367, 0.000000012790717852285, 0.00000048225372718507, 0.0000022922076337661, -0.000000000016714766451061, -0.0021171472321355, -23.895741934104, -5.905956432427E-18, -0.0000012621808899101, -0.038946842435739, 0.000000000011256211360459, -8.2311340897998, 0.000000019809712802088, 1.0406965210174E-19, -0.00000000000010234747095929, -0.0000000010018179379511, -0.000000000080882908646985, 0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 0.00000000000030629316876232, -0.0000042002467698208, -5.9056029685639E-26, 0.0000037826947613457, -0.0000000000000012768608934681, 7.3087610595061E-29, 5.5414715350778E-17, -0.0000009436970724121 };

            double pi = p;
            double tau = 540 / T;
            double g0_tautau = 0;
            for (int I = 0; I < 9; I++)
            {
                g0_tautau = g0_tautau + n0[I] * J0[I] * (J0[I] - 1) * Math.Pow(tau, J0[I] - 2);
            }
            double gr_pi = 0;
            double gr_pitau = 0;
            double gr_pipi = 0;
            double gr_tautau = 0;
            for (int I = 0; I < 43; I++)
            {
                gr_pi = gr_pi + nr[I] * Ir[I] * Math.Pow(pi, Ir[I] - 1) * Math.Pow(tau - 0.5, Jr[I]);
                gr_pipi = gr_pipi + nr[I] * Ir[I] * (Ir[I] - 1) * Math.Pow(pi, Ir[I] - 2) * Math.Pow(tau - 0.5, Jr[I]);
                gr_pitau = gr_pitau + nr[I] * Ir[I] * Math.Pow(pi, Ir[I] - 1) * Jr[I] * Math.Pow(tau - 0.5, Jr[I] - 1);
                gr_tautau = gr_tautau + nr[I] * Math.Pow(pi, Ir[I]) * Jr[I] * (Jr[I] - 1) * Math.Pow(tau - 0.5, Jr[I] - 2);
            }
            return Math.Pow(1000 * R * T * (1 + 2 * pi * gr_pi + Math.Pow(pi, 2) * Math.Pow(gr_pi, 2)) / ((1 - Math.Pow(pi, 2) * gr_pipi) + Math.Pow(1 + pi * gr_pi - tau * pi * gr_pitau, 2) / (Math.Pow(tau, 2) * (g0_tautau + gr_tautau))), 0.5);

        }
        private static double _T2PH(double p, double h)
        {
            /* Release on the IAPWS Industrial Formulation 1997
             for the Thermodynamic Properties of Water and Steam, September 1997
            6 Equations for Region 2,6.3.1 The Backward Equations T( p, h ) for Subregions 2a, 2b, and 2c*/
            if (p < 4)
            {

                // Subregion A
                // Table 20, Eq 22, page 22
                int[] Ji = {0, 1, 2, 3, 7, 20, 0, 1, 2, 3, 7, 9, 11, 18, 44, 0, 2, 7, 36, 38, 40, 42, 44, 24, 44, 12, 32, 44, 32, 36,
              42, 34, 44, 28};
                int[] Ii = { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7 };
                double[] ni = {1089.8952318288, 849.51654495535, -107.81748091826, 33.153654801263, -7.4232016790248, 11.765048724356,
              1.844574935579, -4.1792700549624, 6.2478196935812, -17.344563108114, -200.58176862096, 271.96065473796,
              -455.11318285818, 3091.9688604755, 252266.40357872, -0.0061707422868339, -0.31078046629583,
              11.670873077107, 128127984.04046, -985549096.23276, 2822454697.3002, -3594897141.0703, 1722734991.3197,
              -13551.334240775, 12848734.66465, 1.3865724283226, 235988.32556514, -13105236.545054, 7399.9835474766,
              -551966.9703006, 3715408.5996233, 19127.72923966, -415351.64835634, -62.459855192507};
                double ts = 0;
                double hs = h / 2000;
                for (int I = 0; I < 34; I++) ts = ts + ni[I] * Math.Pow(p, Ii[I]) * Math.Pow(hs - 2.1, Ji[I]);
                return ts;
            }

            if (p < (905.84278514723 - 0.67955786399241 * h + 0.00012809002730136 * Math.Pow(h, 2)))
            {

                // Subregion B
                // Table 21, Eq 23, page 23
                int[] Ji = {0, 1, 2, 12, 18, 24, 28, 40, 0, 2, 6, 12, 18, 24, 28, 40, 2, 8, 18, 40, 1, 2, 12, 24, 2, 12, 18, 24, 28,
              40, 18, 24, 40, 28, 2, 28, 1, 40};
                int[] Ii = {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 5, 5, 6, 7,
              7, 9, 9};
                double[] ni = {1489.5041079516, 743.07798314034, -97.708318797837, 2.4742464705674, -0.63281320016026, 1.1385952129658,
              -0.47811863648625, 0.0085208123431544, 0.93747147377932, 3.3593118604916, 3.3809355601454,
              0.16844539671904, 0.73875745236695, -0.47128737436186, 0.15020273139707, -0.002176411421975,
              -0.021810755324761, -0.10829784403677, -0.046333324635812, 0.000071280351959551, 0.00011032831789999,
              0.00018955248387902, 0.0030891541160537, 0.0013555504554949, 0.00000028640237477456,
              -0.000010779857357512, -0.000076462712454814, 0.000014052392818316, -0.000031083814331434,
              -0.0000010302738212103, 0.0000002821728163504, 0.0000012704902271945, 0.000000073803353468292,
              -0.000000011030139238909, -0.000000000000081456365207833, -0.000000000025180545682962,
              -1.7565233969407E-18, 0.0000000000000086934156344163};
                double ts = 0;
                double hs = h / 2000;
                for (int I = 0; I < 38; I++) ts = ts + ni[I] * Math.Pow(p - 2, Ii[I]) * Math.Pow(hs - 2.6, Ji[I]);
                return ts;
            }
            else {
                // Subregion C
                // Table 22, Eq 24, page 24
                int[] Ji = { 0, 4, 0, 2, 0, 2, 0, 1, 0, 2, 0, 1, 4, 8, 4, 0, 1, 4, 10, 12, 16, 20, 22 };
                int[] Ii = { -7, -7, -6, -6, -5, -5, -2, -2, -1, -1, 0, 0, 1, 1, 2, 6, 6, 6, 6, 6, 6, 6, 6 };
                double[] ni = { -3236839855524.2, 7326335090218.1, 358250899454.47, -583401318515.9, -10783068217.47, 20825544563.171, 610747.83564516, 859777.2253558, -25745.72360417, 31081.088422714, 1208.2315865936, 482.19755109255, 3.7966001272486, -10.842984880077, -0.04536417267666, 0.00000000000014559115658698, 0.000000000001126159740723, -0.000000000017804982240686, 0.00000012324579690832, -0.0000011606921130984, 0.000027846367088554, -0.00059270038474176, 0.0012918582991878 };
                double ts = 0;
                double hs = h / 2000;
                for (int I = 0; I < 23; I++) ts = ts + ni[I] * Math.Pow(p + 25, Ii[I]) * Math.Pow(hs - 1.8, Ji[I]);
                return ts;
            }

        }
        private static double _T2HS(double h, double s) => _T2PH(_P2HS(h, s), h);


        private static double _T2PS(double p, double s)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 6 Equations for Region 2,6.3.2 The Backward Equations T( p, s ) for Subregions 2a, 2b, and 2c
            // Page 26
            if (p < 4)
            {
                // Subregion A
                // Table 25, Eq 25, page 26
                double[] Ii = {-1.5, -1.5, -1.5, -1.5, -1.5, -1.5, -1.25, -1.25, -1.25, -1, -1, -1, -1, -1, -1, -0.75, -0.75, -0.5, -0.5,
              -0.5, -0.5, -0.25, -0.25, -0.25, -0.25, 0.25, 0.25, 0.25, 0.25, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.75,
              0.75, 0.75, 0.75, 1, 1, 1.25, 1.25, 1.5, 1.5};
                int[] Ji = {-24, -23, -19, -13, -11, -10, -19, -15, -6, -26, -21, -17, -16, -9, -8, -15, -14, -26, -13, -9, -7, -27,
              -25, -11, -6, 1, 4, 8, 11, 0, 1, 5, 6, 10, 14, 16, 0, 4, 9, 17, 7, 18, 3, 15, 5, 18};
                double[] ni = {-392359.83861984, 515265.7382727, 40482.443161048, -321.93790923902, 96.961424218694, -22.867846371773,
              -449429.14124357, -5011.8336020166, 0.35684463560015, 44235.33584819, -13673.388811708, 421632.60207864,
              22516.925837475, 474.42144865646, -149.31130797647, -197811.26320452, -23554.39947076, -19070.616302076,
              55375.669883164, 3829.3691437363, -603.91860580567, 1936.3102620331, 4266.064369861, -5978.0638872718,
              -704.01463926862, 338.36784107553, 20.862786635187, 0.033834172656196, -0.000043124428414893,
              166.53791356412, -139.86292055898, -0.78849547999872, 0.072132411753872, -0.0059754839398283,
              -0.000012141358953904, 0.00000023227096733871, -10.538463566194, 2.0718925496502, -0.072193155260427,
              0.0000002074988708112, -0.018340657911379, 0.00000029036272348696, 0.21037527893619, 0.00025681239729999,
              -0.012799002933781, -0.0000082198102652018};
                double pi = p;
                double Sigma = s / 2;
                double teta = 0;
                for (int I = 0; I < 46; I++) teta = teta + ni[I] * Math.Pow(pi, Ii[I]) * Math.Pow(Sigma - 2, Ji[I]);
                return teta;
            }

            if (s < 5.85)
            {
                // Subregion C
                // Table 27, Eq 27, page 28
                int[] Ii = { -2, -2, -1, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7, 7, 7, 7, 7 };
                int[] Ji = { 0, 1, 0, 0, 1, 2, 3, 0, 1, 3, 4, 0, 1, 2, 0, 1, 5, 0, 1, 4, 0, 1, 2, 0, 1, 0, 1, 3, 4, 5 };
                double[] ni = {909.68501005365, 2404.566708842, -591.6232638713, 541.45404128074, -270.98308411192, 979.76525097926,
              -469.66772959435, 14.399274604723, -19.104204230429, 5.3299167111971, -21.252975375934, -0.3114733441376,
              0.60334840894623, -0.042764839702509, 0.0058185597255259, -0.014597008284753, 0.0056631175631027,
              -0.000076155864584577, 0.00022440342919332, -0.000012561095013413, 0.00000063323132660934,
              -0.0000020541989675375, 0.000000036405370390082, -0.0000000029759897789215, 0.000000010136618529763,
              0.0000000000059925719692351, -0.000000000020677870105164, -0.000000000020874278181886,
              0.00000000010162166825089, -0.00000000016429828281347};
                double pi = p;
                double Sigma = s / 2.9251;
                double teta = 0;
                for (int I = 0; I < 30; I++) teta = teta + ni[I] * Math.Pow(pi, Ii[I]) * Math.Pow(2 - Sigma, Ji[I]);
                return teta;
            }
            else {
                // Subregion B
                // Table 26, Eq 26, page 27
                int[] Ii = { -6, -6, -5, -5, -4, -4, -4, -3, -3, -3, -3, -2, -2, -2, -2, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 5, 5, 5 };
                int[] Ji = { 0, 11, 0, 11, 0, 1, 11, 0, 1, 11, 12, 0, 1, 6, 10, 0, 1, 5, 8, 9, 0, 1, 2, 4, 5, 6, 9, 0, 1, 2, 3, 7, 8, 0, 1, 5, 0, 1, 3, 0, 1, 0, 1, 2 };
                double[] ni = { 316876.65083497, 20.864175881858, -398593.99803599, -21.816058518877, 223697.85194242, -2784.1703445817, 9.920743607148, -75197.512299157, 2970.8605951158, -3.4406878548526, 0.38815564249115, 17511.29508575, -1423.7112854449, 1.0943803364167, 0.89971619308495, -3375.9740098958, 471.62885818355, -1.9188241993679, 0.41078580492196, -0.33465378172097, 1387.0034777505, -406.63326195838, 41.72734715961, 2.1932549434532, -1.0320050009077, 0.35882943516703, 0.0052511453726066, 12.838916450705, -2.8642437219381, 0.56912683664855, -0.099962954584931, -0.0032632037778459, 0.00023320922576723, -0.1533480985745, 0.029072288239902, 0.00037534702741167, 0.0017296691702411, -0.00038556050844504, -0.000035017712292608, -0.000014566393631492, 0.0000056420857267269, 0.000000041286150074605, -0.000000020684671118824, 0.0000000016409393674725 };
                double pi = p;
                double Sigma = s / 0.7853;
                double teta = 0;
                for (int I = 0; I < 44; I++) teta = teta + ni[I] * Math.Pow(pi, Ii[I]) * Math.Pow(10 - Sigma, Ji[I]);
                return teta;
            }

        }
        private static double _P2HS(double h, double s)
        {
            // Supplementary Release on Backward Equations for Pressure as a Function of Enthalpy and Entropy p(h,s) to the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam
            // Chapter 6:Backward Equations p(h,s) for Region 2
            if (h < (-3498.98083432139 + 2575.60716905876 * s - 421.073558227969 * Math.Pow(s, 2) + 27.6349063799944 * Math.Pow(s, 3)))
            {
                // Subregion A
                // Table 6, Eq 3, page 8
                int[] Ii = { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 3, 4, 5, 5, 6, 7 };
                int[] Ji = { 1, 3, 6, 16, 20, 22, 0, 1, 2, 3, 5, 6, 10, 16, 20, 22, 3, 16, 20, 0, 2, 3, 6, 16, 16, 3, 16, 3, 1 };
                double[] ni = {-0.0182575361923032, -0.125229548799536, 0.592290437320145, 6.04769706185122, 238.624965444474,
              -298.639090222922, 0.051225081304075, -0.437266515606486, 0.413336902999504, -5.16468254574773,
              -5.57014838445711, 12.8555037824478, 11.414410895329, -119.504225652714, -2847.7798596156,
              4317.57846408006, 1.1289404080265, 1974.09186206319, 1516.12444706087, 0.0141324451421235,
              0.585501282219601, -2.97258075863012, 5.94567314847319, -6236.56565798905, 9659.86235133332,
              6.81500934948134, -6332.07286824489, -5.5891922446576, 0.0400645798472063};
                double eta = h / 4200;
                double Sigma = s / 12;
                double pi = 0;
                for (int I = 0; I < 29; I++) pi = pi + ni[I] * Math.Pow(eta - 0.5, Ii[I]) * Math.Pow(Sigma - 1.2, Ji[I]);
                return Math.Pow(pi, 4) * 4;
            }
            else if (s < 5.85)
            {
                // Subregion C
                // Table 8, Eq 5, page 10
                int[] Ii = { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 5, 5, 5, 5, 6, 6, 10, 12, 16 };
                int[] Ji = { 0, 1, 2, 3, 4, 8, 0, 2, 5, 8, 14, 2, 3, 7, 10, 18, 0, 5, 8, 16, 18, 18, 1, 4, 6, 14, 8, 18, 7, 7, 10 };
                double[] ni = {0.112225607199012, -3.39005953606712, -32.0503911730094, -197.5973051049, -407.693861553446,
              13294.3775222331, 1.70846839774007, 37.3694198142245, 3581.44365815434, 423014.446424664,
              -751071025.760063, 52.3446127607898, -228.351290812417, -960652.417056937, -80705929.2526074,
              1626980172256.69, 0.772465073604171, 46392.9973837746, -13731788.5134128, 1704703926305.12,
              -25110462818730.8, 31774883083552.0, // Проверить
			  53.8685623675312, -55308.9094625169, -1028615.22421405, 2042494187562.34, 273918446.626977,
              -2.63963146312685E+15, -1078908541.08088, -29649262098.0124, -1.11754907323424E+15};
                double eta = h / 3500;
                double Sigma = s / 5.9;
                double pi = 0;
                for (int I = 0; I < 31; I++) pi = pi + ni[I] * Math.Pow(eta - 0.7, Ii[I]) * Math.Pow(Sigma - 1.1, Ji[I]);
                return Math.Pow(pi, 4) * 100;
            }
            else {
                // Subregion B
                // Table 7, Eq 4, page 9
                int[] Ii = { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 5, 5, 6, 6, 6, 7, 7, 8, 8, 8, 8, 12, 14 };
                int[] Ji = { 0, 1, 2, 4, 8, 0, 1, 2, 3, 5, 12, 1, 6, 18, 0, 1, 7, 12, 1, 16, 1, 12, 1, 8, 18, 1, 16, 1, 3, 14, 18, 10, 16 };
                double[] ni = {0.0801496989929495, -0.543862807146111, 0.337455597421283, 8.9055545115745, 313.840736431485,
              0.797367065977789, -1.2161697355624, 8.72803386937477, -16.9769781757602, -186.552827328416,
              95115.9274344237, -18.9168510120494, -4334.0703719484, 543212633.012715, 0.144793408386013,
              128.024559637516, -67230.9534071268, 33697238.0095287, -586.63419676272, -22140322476.9889,
              1716.06668708389, -570817595.806302, -3121.09693178482, -2078413.8463301, 3056059461577.86,
              3221.57004314333, 326810259797.295, -1441.04158934487, 410.694867802691, 109077066873.024,
              -24796465425889.3, 1888019068.65134, -123651009018773.0}; // Проверить
                double eta = h / 4100;
                double Sigma = s / 7.9;
                double pi = 0;
                for (int I = 0; I < 33; I++) pi = pi + ni[I] * Math.Pow(eta - 0.6, Ii[I]) * Math.Pow(Sigma - 1.01, Ji[I]);
                return Math.Pow(pi, 4) * 100;
            }

        }
        private static double _T2PD(double p, double rho)
        {
            // Solve by iteration. Observe that fo low temperatures this equation has 2 solutions.
            // Solve with half interval method
            double Low_Bound = (p < 16.5292) ? _T4P(p) : _TB23P(p);
            double High_Bound = 1073.15;
            while (true)
            {
                double ts = (Low_Bound + High_Bound) / 2;
                double rhos = 1.0 / _V2PT(p, ts);
                if (Math.Abs(rho - rhos) < 0.000001) return ts;
                if (rhos < rho) High_Bound = ts;
                else Low_Bound = ts;
            }
        }
        #endregion
        // ***********************************************************************************************************
        # region *2.3 Functions for region 3

        private static double _P3DT(double rho, double T)
        {
            /*Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            7 Basic Equation for Region 3, Section. 6.1 Basic Equation
            Table 30 and 31, Page 30 and 31
            >>> _P3DT(500, 650)
            25.58370181852195
            */
            int[] Ii = {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3,
          3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 8, 9, 9, 10, 10, 11};
            int[] Ji = {0, 1, 2, 7, 10, 12, 23, 2, 6, 15, 17, 0, 2, 6, 7, 22,
          26, 0, 2, 4, 16, 26, 0, 2, 4, 26, 1, 3, 26, 0, 2, 26, 2, 26, 2, 26, 0, 1, 26};
            double[] ni = {-15.732845290239, 20.944396974307, -7.6867707878716,
          2.6185947787954, -2.808078114862, 1.2053369696517, -0.0084566812812502,
          -1.2654315477714, -1.1524407806681, 0.88521043984318, -0.64207765181607,
          0.38493460186671, -0.85214708824206, 4.8972281541877, -3.0502617256965,
          0.039420536879154, 0.12558408424308, -0.2799932969871, 1.389979956946,
          -2.018991502357, -0.0082147637173963, -0.47596035734923, 0.0439840744735,
          -0.44476435428739, 0.90572070719733, 0.70522450087967, 0.10770512626332,
          -0.32913623258954, -0.50871062041158, -0.022175400873096, 0.094260751665092,
          0.16436278447961, -0.013503372241348, -0.014834345352472, 0.00057922953628084,
          0.0032308904703711, 0.000080964802996215, -0.00016557679795037, -0.000044923899061815};

            double delta = rho / rhoc;
            double tau = tc / T;
            double fidelta = 1.0658070028513 / delta;
            int k = 0;
            foreach (var i in Ii)
            {
                var j = Ji[k]; var n = ni[k];
                fidelta += n * i * Math.Pow(delta, i - 1) * Math.Pow(tau, j);
                k++;
            }
            return rho * R * T * delta * fidelta / 1000;
        }

        private static double _U3DT(double rho, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 7 Basic Equation for Region 3, Section. 6.1 Basic Equation
            // Table 30 and 31, Page 30 and 31
            int[] Ii = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 8, 9, 9, 10, 10, 11 };
            int[] Ji = { 0, 0, 1, 2, 7, 10, 12, 23, 2, 6, 15, 17, 0, 2, 6, 7, 22, 26, 0, 2, 4, 16, 26, 0, 2, 4, 26, 1, 3, 26, 0, 2, 26, 2, 26, 2, 26, 0, 1, 26 };
            double[] ni = { 1.0658070028513, -15.732845290239, 20.944396974307, -7.6867707878716, 2.6185947787954, -2.808078114862, 1.2053369696517, -0.0084566812812502, -1.2654315477714, -1.1524407806681, 0.88521043984318, -0.64207765181607, 0.38493460186671, -0.85214708824206, 4.8972281541877, -3.0502617256965, 0.039420536879154, 0.12558408424308, -0.2799932969871, 1.389979956946, -2.018991502357, -0.0082147637173963, -0.47596035734923, 0.0439840744735, -0.44476435428739, 0.90572070719733, 0.70522450087967, 0.10770512626332, -0.32913623258954, -0.50871062041158, -0.022175400873096, 0.094260751665092, 0.16436278447961, -0.013503372241348, -0.014834345352472, 0.00057922953628084, 0.0032308904703711, 0.000080964802996215, -0.00016557679795037, -0.000044923899061815 };

            double delta = rho / rhoc;
            double tau = tc / T;
            double fitau = 0;
            for (int I = 0; I < 40; I++) fitau = fitau + ni[I] * Math.Pow(delta, Ii[I]) * Ji[I] * Math.Pow(tau, Ji[I] - 1);
            return R * T * (tau * fitau);
        }

        private static double _H3DT(double rho, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 7 Basic Equation for Region 3, Section. 6.1 Basic Equation
            // Table 30 and 31, Page 30 and 31
            int[] Ii = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 8, 9, 9, 10, 10, 11 };
            int[] Ji = { 0, 0, 1, 2, 7, 10, 12, 23, 2, 6, 15, 17, 0, 2, 6, 7, 22, 26, 0, 2, 4, 16, 26, 0, 2, 4, 26, 1, 3, 26, 0, 2, 26, 2, 26, 2, 26, 0, 1, 26 };
            double[] ni = { 1.0658070028513, -15.732845290239, 20.944396974307, -7.6867707878716, 2.6185947787954, -2.808078114862, 1.2053369696517, -0.0084566812812502, -1.2654315477714, -1.1524407806681, 0.88521043984318, -0.64207765181607, 0.38493460186671, -0.85214708824206, 4.8972281541877, -3.0502617256965, 0.039420536879154, 0.12558408424308, -0.2799932969871, 1.389979956946, -2.018991502357, -0.0082147637173963, -0.47596035734923, 0.0439840744735, -0.44476435428739, 0.90572070719733, 0.70522450087967, 0.10770512626332, -0.32913623258954, -0.50871062041158, -0.022175400873096, 0.094260751665092, 0.16436278447961, -0.013503372241348, -0.014834345352472, 0.00057922953628084, 0.0032308904703711, 0.000080964802996215, -0.00016557679795037, -0.000044923899061815 };

            double delta = rho / rhoc;
            double tau = tc / T;
            double fidelta = 0;
            double fitau = 0;
            for (int I = 0; I < 40; I++)
            {
                fidelta = fidelta + ni[I] * Ii[I] * Math.Pow(delta, Ii[I] - 1) * Math.Pow(tau, Ji[I]);
                fitau = fitau + ni[I] * Math.Pow(delta, Ii[I]) * Ji[I] * Math.Pow(tau, Ji[I] - 1);
            }
            fidelta = fidelta + ni[0] / delta;
            return R * T * (tau * fitau + delta * fidelta);
        }
        private static double _S3DT(double rho, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 7 Basic Equation for Region 3, Section. 6.1 Basic Equation
            // Table 30 and 31, Page 30 and 31
            int[] Ii = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 8, 9, 9, 10, 10, 11 };
            int[] Ji = { 0, 0, 1, 2, 7, 10, 12, 23, 2, 6, 15, 17, 0, 2, 6, 7, 22, 26, 0, 2, 4, 16, 26, 0, 2, 4, 26, 1, 3, 26, 0, 2, 26, 2, 26, 2, 26, 0, 1, 26 };
            double[] ni = { 1.0658070028513, -15.732845290239, 20.944396974307, -7.6867707878716, 2.6185947787954, -2.808078114862, 1.2053369696517, -0.0084566812812502, -1.2654315477714, -1.1524407806681, 0.88521043984318, -0.64207765181607, 0.38493460186671, -0.85214708824206, 4.8972281541877, -3.0502617256965, 0.039420536879154, 0.12558408424308, -0.2799932969871, 1.389979956946, -2.018991502357, -0.0082147637173963, -0.47596035734923, 0.0439840744735, -0.44476435428739, 0.90572070719733, 0.70522450087967, 0.10770512626332, -0.32913623258954, -0.50871062041158, -0.022175400873096, 0.094260751665092, 0.16436278447961, -0.013503372241348, -0.014834345352472, 0.00057922953628084, 0.0032308904703711, 0.000080964802996215, -0.00016557679795037, -0.000044923899061815 };




            double delta = rho / rhoc;
            double tau = tc / T;
            double fi = 0;
            double fitau = 0;
            for (int I = 0; I < 40; I++)
            {
                fi = fi + ni[I] * Math.Pow(delta, Ii[I]) * Math.Pow(tau, Ji[I]);
                fitau = fitau + ni[I] * Math.Pow(delta, Ii[I]) * Ji[I] * Math.Pow(tau, Ji[I] - 1);
            }
            fi = fi + ni[0] * Math.Log(delta);
            return R * (tau * fitau - fi);

        }
        private static double _CP3DT(double rho, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 7 Basic Equation for Region 3, Section. 6.1 Basic Equation
            // Table 30 and 31, Page 30 and 31
            int[] Ii = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 8, 9, 9, 10, 10, 11 };
            int[] Ji = { 0, 0, 1, 2, 7, 10, 12, 23, 2, 6, 15, 17, 0, 2, 6, 7, 22, 26, 0, 2, 4, 16, 26, 0, 2, 4, 26, 1, 3, 26, 0, 2, 26, 2, 26, 2, 26, 0, 1, 26 };
            double[] ni = { 1.0658070028513, -15.732845290239, 20.944396974307, -7.6867707878716, 2.6185947787954, -2.808078114862, 1.2053369696517, -0.0084566812812502, -1.2654315477714, -1.1524407806681, 0.88521043984318, -0.64207765181607, 0.38493460186671, -0.85214708824206, 4.8972281541877, -3.0502617256965, 0.039420536879154, 0.12558408424308, -0.2799932969871, 1.389979956946, -2.018991502357, -0.0082147637173963, -0.47596035734923, 0.0439840744735, -0.44476435428739, 0.90572070719733, 0.70522450087967, 0.10770512626332, -0.32913623258954, -0.50871062041158, -0.022175400873096, 0.094260751665092, 0.16436278447961, -0.013503372241348, -0.014834345352472, 0.00057922953628084, 0.0032308904703711, 0.000080964802996215, -0.00016557679795037, -0.000044923899061815 };

            double delta = rho / rhoc;
            double tau = tc / T;
            double fitautau = 0;
            double fidelta = 0;
            double fideltatau = 0;
            double fideltadelta = 0;
            for (int I = 0; I < 40; I++)
            {
                fitautau = fitautau + ni[I] * Math.Pow(delta, Ii[I]) * Ji[I] * (Ji[I] - 1) * Math.Pow(tau, Ji[I] - 2);
                fidelta = fidelta + ni[I] * Ii[I] * Math.Pow(delta, Ii[I] - 1) * Math.Pow(tau, Ji[I]);
                fideltatau = fideltatau + ni[I] * Ii[I] * Math.Pow(delta, Ii[I] - 1) * Ji[I] * Math.Pow(tau, Ji[I] - 1);
                fideltadelta = fideltadelta + ni[I] * Ii[I] * (Ii[I] - 1) * Math.Pow(delta, Ii[I] - 2) * Math.Pow(tau, Ji[I]);
            }
            fidelta = fidelta + ni[0] / delta;
            fideltadelta = fideltadelta - ni[0] / Math.Pow(delta, 2);
            return R * (-Math.Pow(tau, 2) * fitautau + Math.Pow(delta * fidelta - delta * tau * fideltatau, 2) / (2 * delta * fidelta + Math.Pow(delta, 2) * fideltadelta));
        }

        private static double _CV3DT(double rho, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 7 Basic Equation for Region 3, Section. 6.1 Basic Equation
            // Table 30 and 31, Page 30 and 31
            int[] Ii = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 8, 9, 9, 10, 10, 11 };
            int[] Ji = { 0, 0, 1, 2, 7, 10, 12, 23, 2, 6, 15, 17, 0, 2, 6, 7, 22, 26, 0, 2, 4, 16, 26, 0, 2, 4, 26, 1, 3, 26, 0, 2, 26, 2, 26, 2, 26, 0, 1, 26 };
            double[] ni = { 1.0658070028513, -15.732845290239, 20.944396974307, -7.6867707878716, 2.6185947787954, -2.808078114862, 1.2053369696517, -0.0084566812812502, -1.2654315477714, -1.1524407806681, 0.88521043984318, -0.64207765181607, 0.38493460186671, -0.85214708824206, 4.8972281541877, -3.0502617256965, 0.039420536879154, 0.12558408424308, -0.2799932969871, 1.389979956946, -2.018991502357, -0.0082147637173963, -0.47596035734923, 0.0439840744735, -0.44476435428739, 0.90572070719733, 0.70522450087967, 0.10770512626332, -0.32913623258954, -0.50871062041158, -0.022175400873096, 0.094260751665092, 0.16436278447961, -0.013503372241348, -0.014834345352472, 0.00057922953628084, 0.0032308904703711, 0.000080964802996215, -0.00016557679795037, -0.000044923899061815 };

            double delta = rho / rhoc;
            double tau = tc / T;
            double fitautau = 0;
            for (int I = 0; I < 40; I++) fitautau = fitautau + ni[I] * Math.Pow(delta, Ii[I]) * Ji[I] * (Ji[I] - 1) * Math.Pow(tau, Ji[I] - 2);
            return R * -(tau * tau * fitautau);
        }

        private static double _W3DT(double rho, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // 7 Basic Equation for Region 3, Section. 6.1 Basic Equation
            // Table 30 and 31, Page 30 and 31
            int[] Ii = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 8, 9, 9, 10, 10, 11 };
            int[] Ji = { 0, 0, 1, 2, 7, 10, 12, 23, 2, 6, 15, 17, 0, 2, 6, 7, 22, 26, 0, 2, 4, 16, 26, 0, 2, 4, 26, 1, 3, 26, 0, 2, 26, 2, 26, 2, 26, 0, 1, 26 };
            double[] ni = { 1.0658070028513, -15.732845290239, 20.944396974307, -7.6867707878716, 2.6185947787954, -2.808078114862, 1.2053369696517, -0.0084566812812502, -1.2654315477714, -1.1524407806681, 0.88521043984318, -0.64207765181607, 0.38493460186671, -0.85214708824206, 4.8972281541877, -3.0502617256965, 0.039420536879154, 0.12558408424308, -0.2799932969871, 1.389979956946, -2.018991502357, -0.0082147637173963, -0.47596035734923, 0.0439840744735, -0.44476435428739, 0.90572070719733, 0.70522450087967, 0.10770512626332, -0.32913623258954, -0.50871062041158, -0.022175400873096, 0.094260751665092, 0.16436278447961, -0.013503372241348, -0.014834345352472, 0.00057922953628084, 0.0032308904703711, 0.000080964802996215, -0.00016557679795037, -0.000044923899061815 };

            double delta = rho / rhoc;
            double tau = tc / T;
            double fitautau = 0;
            double fidelta = 0;
            double fideltatau = 0;
            double fideltadelta = 0;
            for (int I = 0; I < 40; I++)
            {
                fitautau = fitautau + ni[I] * Math.Pow(delta, Ii[I]) * Ji[I] * (Ji[I] - 1) * Math.Pow(tau, Ji[I] - 2);
                fidelta = fidelta + ni[I] * Ii[I] * Math.Pow(delta, Ii[I] - 1) * Math.Pow(tau, Ji[I]);
                fideltatau = fideltatau + ni[I] * Ii[I] * Math.Pow(delta, Ii[I] - 1) * Ji[I] * Math.Pow(tau, Ji[I] - 1);
                fideltadelta = fideltadelta + ni[I] * Ii[I] * (Ii[I] - 1) * Math.Pow(delta, Ii[I] - 2) * Math.Pow(tau, Ji[I]);
            }
            fidelta = fidelta + ni[0] / delta;
            fideltadelta = fideltadelta - ni[0] / (Math.Pow(delta, 2));
            return Math.Sqrt(1000 * R * T * (2 * delta * fidelta + Math.Pow(delta, 2) * fideltadelta - Math.Pow(delta * fidelta - delta * tau * fideltatau, 2) / (Math.Pow(tau, 2) * fitautau)));
        }

        private static double _T3PH(double p, double h)
        {
            // Revised Supplementary Release on Backward Equations for the Functions T(p,h), v(p,h) and T(p,s), v(p,s) for Region 3 of the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam
            // 2004
            // Section 3.3 Backward Equations T(p,h) and v(p,h) for Subregions 3a and 3b
            // Boundary equation, Eq 1 Page 5
            double h3ab = (2014.64004206875 + 3.74696550136983 * p - 0.0219921901054187 * Math.Pow(p, 2) + 0.000087513168600995 * Math.Pow(p, 3));
            if (h < h3ab)
            {
                // Subregion 3a
                // Eq 2, Table 3, Page 7
                int[] Ii = {-12, -12, -12, -12, -12, -12, -12, -12, -10, -10, -10,
                    -8, -8, -8, -8, -5, -3, -2, -2, -2, -1,
                    -1, 0, 0, 1, 3, 3, 4, 4, 10, 12};
                int[] Ji = { 0, 1, 2, 6, 14, 16, 20, 22, 1, 5, 12, 0, 2, 4, 10, 2, 0, 1, 3, 4, 0, 2, 0, 1, 1, 0, 1, 0, 3, 4, 5 };
                double[] ni = {-0.000000133645667811215, 0.00000455912656802978, -0.0000146294640700979, 0.0063934131297008,
              372.783927268847, -7186.54377460447, 573494.7521034, -2675693.29111439, -0.0000334066283302614,
              -0.0245479214069597, 47.8087847764996, 0.00000764664131818904, 0.00128350627676972,
              0.0171219081377331, -8.51007304583213, -0.0136513461629781, -0.00000384460997596657,
              0.00337423807911655, -0.551624873066791, 0.72920227710747, -0.00992522757376041,
              -0.119308831407288, 0.793929190615421, 0.454270731799386, 0.20999859125991,
              -0.00642109823904738, -0.023515586860454, 0.00252233108341612, -0.00764885133368119,
              0.0136176427574291, -0.0133027883575669};
                double ps = p / 100;
                double hs = h / 2300;
                double ts = 0;
                for (int I = 0; I < 30; I++) ts = ts + ni[I] * Math.Pow(ps + 0.24, Ii[I]) * Math.Pow(hs - 0.615, Ji[I]);
                return ts * 760;
            }
            else
            {

                // Subregion 3b
                // Eq 3, Table 4, Page 7,8
                int[] Ii = { -12, -12, -10, -10, -10, -10, -10, -8, -8, -8, -8, -8, -6, -6, -6, -4, -4, -3, -2, -2, -1, -1, -1, -1, -1, -1, 0, 0, 1, 3, 5, 6, 8 };
                int[] Ji = { 0, 1, 0, 1, 5, 10, 12, 0, 1, 2, 4, 10, 0, 1, 2, 0, 1, 5, 0, 4, 2, 4, 6, 10, 14, 16, 0, 2, 1, 1, 1, 1, 1 };
                double[] ni = { 0.000032325457364492, -0.000127575556587181, -0.000475851877356068, 0.00156183014181602, 0.105724860113781, -85.8514221132534, 724.140095480911, 0.00296475810273257, -0.00592721983365988, -0.0126305422818666, -0.115716196364853, 84.9000969739595, -0.0108602260086615, 0.0154304475328851, 0.0750455441524466, 0.0252520973612982, -0.0602507901232996, -3.07622221350501, -0.0574011959864879, 5.03471360939849, -0.925081888584834, 3.91733882917546, -77.314600713019, 9493.08762098587, -1410437.19679409, 8491662.30819026, 0.861095729446704, 0.32334644281172, 0.873281936020439, -0.436653048526683, 0.286596714529479, -0.131778331276228, 0.00676682064330275 };
                double hs = h / 2800;
                double ps = p / 100;
                double ts = 0;
                for (int I = 0; I < 33; I++) ts = ts + ni[I] * Math.Pow(ps + 0.298, Ii[I]) * Math.Pow(hs - 0.72, Ji[I]);
                return ts * 860;
            }
        }

        private static double _T3HS(double h, double s) => _T3PH(_P3HS(h, s), h);


        private static double _V3PH(double p, double h)
        {
            // Revised Supplementary Release on Backward Equations for the Functions T(p,h), v(p,h) and T(p,s), v(p,s) for Region 3 of the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam
            // 2004
            // Section 3.3 Backward Equations T(p,h) and v(p,h) for Subregions 3a and 3b
            // Boundary equation, Eq 1 Page 5
            double h3ab = (2014.64004206875 + 3.74696550136983 * p - 0.0219921901054187 * Math.Pow(p, 2) + 0.000087513168600995 * Math.Pow(p, 3));
            if (h < h3ab)
            {
                // Subregion 3a
                // Eq 4, Table 6, Page 9
                int[] Ii = { -12, -12, -12, -12, -10, -10, -10, -8, -8, -6, -6, -6, -4, -4, -3, -2, -2, -1, -1, -1, -1, 0, 0, 1, 1, 1, 2, 2, 3, 4, 5, 8 };
                int[] Ji = { 6, 8, 12, 18, 4, 7, 10, 5, 12, 3, 4, 22, 2, 3, 7, 3, 16, 0, 1, 2, 3, 0, 1, 0, 1, 2, 0, 2, 0, 2, 2, 2 };
                double[] ni = { 0.00529944062966028, -0.170099690234461, 11.1323814312927, -2178.98123145125, -0.000506061827980875, 0.556495239685324, -9.43672726094016, -0.297856807561527, 93.9353943717186, 0.0192944939465981, 0.421740664704763, -3689141.2628233, -0.00737566847600639, -0.354753242424366, -1.99768169338727, 1.15456297059049, 5683.6687581596, 0.00808169540124668, 0.172416341519307, 1.04270175292927, -0.297691372792847, 0.560394465163593, 0.275234661176914, -0.148347894866012, -0.0651142513478515, -2.92468715386302, 0.0664876096952665, 3.52335014263844, -0.0146340792313332, -2.24503486668184, 1.10533464706142, -0.0408757344495612 };
                double ps = p / 100;
                double hs = h / 2100;
                double vs = 0;
                for (int I = 0; I < 32; I++) vs = vs + ni[I] * Math.Pow(ps + 0.128, Ii[I]) * Math.Pow(hs - 0.727, Ji[I]);
                return vs * 0.0028;
            }
            else {

                // Subregion 3b
                // Eq 5, Table 7, Page 9
                int[] Ii = { -12, -12, -8, -8, -8, -8, -8, -8, -6, -6, -6, -6, -6, -6, -4, -4, -4, -3, -3, -2, -2, -1, -1, -1, -1, 0, 1, 1, 2, 2 };
                int[] Ji = { 0, 1, 0, 1, 3, 6, 7, 8, 0, 1, 2, 5, 6, 10, 3, 6, 10, 0, 2, 1, 2, 0, 1, 4, 5, 0, 0, 1, 2, 6 };
                double[] ni = { -0.00000000225196934336318, 0.0000000140674363313486, 0.0000023378408528056, -0.0000331833715229001, 0.00107956778514318, -0.271382067378863, 1.07202262490333, -0.853821329075382, -0.0000215214194340526, 0.00076965608822273, -0.00431136580433864, 0.453342167309331, -0.507749535873652, -100.475154528389, -0.219201924648793, -3.21087965668917, 607.567815637771, 0.000557686450685932, 0.18749904002955, 0.00905368030448107, 0.285417173048685, 0.0329924030996098, 0.239897419685483, 4.82754995951394, -11.8035753702231, 0.169490044091791, -0.0179967222507787, 0.0371810116332674, -0.0536288335065096, 1.6069710109252 };
                double ps = p / 100;
                double hs = h / 2800;
                double vs = 0;
                for (int I = 0; I < 30; I++) vs = vs + ni[I] * Math.Pow(ps + 0.0661, Ii[I]) * Math.Pow(hs - 0.72, Ji[I]);
                return vs * 0.0088;
            }

        }
        private static double _T3PS(double p, double s)
        {
            /*Revised Supplementary Release on Backward Equations
            for the Functions T(p,h), v(p,h) and T(p,s), v(p,s)
            for Region 3 of the IAPWS Industrial Formulation 1997
            for the Thermodynamic Properties of Water and Steam 2004
            3.4 Backward Equations T(p,s) and v(p,s) for Subregions 3a and 3b
            Boundary equation, Eq 6 Page 11*/
            if (s <= 4.41202148223476)
            {
                // Subregion 3a
                // Eq 6, Table 10, Page 11
                int[] Ii = { -12, -12, -10, -10, -10, -10, -8, -8, -8, -8, -6, -6, -6, -5, -5, -5, -4, -4, -4, -2, -2, -1, -1, 0, 0, 0, 1, 2, 2, 3, 8, 8, 10 };
                int[] Ji = { 28, 32, 4, 10, 12, 14, 5, 7, 8, 28, 2, 6, 32, 0, 14, 32, 6, 10, 36, 1, 4, 1, 6, 0, 1, 4, 0, 0, 3, 2, 0, 1, 2 };
                double[] ni = { 1500420082.63875, -159397258480.424, 0.000502181140217975, -67.2057767855466, 1450.58545404456, -8238.8953488889, -0.154852214233853, 11.2305046746695, -29.7000213482822, 43856513263.5495, 0.00137837838635464, -2.97478527157462, 9717779473494.13, -0.0000571527767052398, 28830.794977842, -74442828926270.3, 12.8017324848921, -368.275545889071, 6.64768904779177E+15, 0.044935925195888, -4.22897836099655, -0.240614376434179, -4.74341365254924, 0.72409399912611, 0.923874349695897, 3.99043655281015, 0.0384066651868009, -0.00359344365571848, -0.735196448821653, 0.188367048396131, 0.000141064266818704, -0.00257418501496337, 0.00123220024851555 };
                double Sigma = s / 4.4;
                double pi = p / 100;
                double teta = 0;
                for (int I = 0; I < 33; I++) teta = teta + ni[I] * Math.Pow(pi + 0.24, Ii[I]) * Math.Pow(Sigma - 0.703, Ji[I]);
                return teta * 760;
            }
            else
            {
                // Subregion 3b
                // Eq 7, Table 11, Page 11
                int[] Ii = { -12, -12, -12, -12, -8, -8, -8, -6, -6, -6, -5, -5, -5, -5, -5, -4, -3, -3, -2, 0, 2, 3, 4, 5, 6, 8, 12, 14 };
                int[] Ji = { 1, 3, 4, 7, 0, 1, 3, 0, 2, 4, 0, 1, 2, 4, 6, 12, 1, 6, 2, 0, 1, 1, 0, 24, 0, 3, 1, 2 };
                double[] ni = { 0.52711170160166, -40.1317830052742, 153.020073134484, -2247.99398218827, -0.193993484669048,
                      -1.40467557893768, 42.6799878114024, 0.752810643416743, 22.6657238616417, -622.873556909932,
                      -0.660823667935396, 0.841267087271658, -25.3717501764397, 485.708963532948, 880.531517490555,
                      2650155.92794626, -0.359287150025783, -656.991567673753, 2.41768149185367, 0.856873461222588,
                      0.655143675313458, -0.213535213206406, 0.00562974957606348, -316955725450471.0,  // Проверить
                      -0.000699997000152457, 0.0119845803210767, 0.0000193848122022095, -0.0000215095749182309};
                double Sigma = s / 5.3;
                double pi = p / 100;
                double teta = 0;
                for (int I = 0; I < 28; I++) teta = teta + ni[I] * Math.Pow(pi + 0.76, Ii[I]) * Math.Pow(Sigma - 0.818, Ji[I]);
                return teta * 860;
            }

        }
        private static double _V3PS(double p, double s)
        {
            // Revised Supplementary Release on Backward Equations for the Functions T(p,h), v(p,h) and T(p,s), v(p,s) for Region 3 of the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam
            // 2004
            // 3.4 Backward Equations T(p,s) and v(p,s) for Subregions 3a and 3b
            // Boundary equation, Eq 6 Page 11
            if (s <= 4.41202148223476)
            {
                // Subregion 3a
                // Eq 8, Table 13, Page 14
                int[] Ii = { -12, -12, -12, -10, -10, -10, -10, -8, -8, -8, -8, -6, -5, -4, -3, -3, -2, -2, -1, -1, 0, 0, 0, 1, 2, 4, 5, 6 };
                int[] Ji = { 10, 12, 14, 4, 8, 10, 20, 5, 6, 14, 16, 28, 1, 5, 2, 4, 3, 8, 1, 2, 0, 1, 3, 0, 0, 2, 2, 0 };
                double[] ni = { 79.5544074093975, -2382.6124298459, 17681.3100617787, -0.00110524727080379, -15.3213833655326, 297.544599376982, -35031520.6871242, 0.277513761062119, -0.523964271036888, -148011.182995403, 1600148.99374266, 1708023226634.27, 0.000246866996006494, 1.6532608479798, -0.118008384666987, 2.537986423559, 0.965127704669424, -28.2172420532826, 0.203224612353823, 1.10648186063513, 0.52612794845128, 0.277000018736321, 1.08153340501132, -0.0744127885357893, 0.0164094443541384, -0.0680468275301065, 0.025798857610164, -0.000145749861944416 };
                double pi = p / 100;
                double Sigma = s / 4.4;
                double omega = 0;
                for (int I = 0; I < 27; I++) omega = omega + ni[I] * Math.Pow(pi + 0.187, Ii[I]) * Math.Pow(Sigma - 0.755, Ji[I]);
                return omega * 0.0028;
            }
            else
            {
                // Subregion 3b
                // Eq 9, Table 14, Page 14
                int[] Ii = { -12, -12, -12, -12, -12, -12, -10, -10, -10, -10, -8, -5, -5, -5, -4, -4, -4, -4, -3, -2, -2, -2, -2, -2, -2, 0, 0, 0, 1, 1, 2 };
                int[] Ji = { 0, 1, 2, 3, 5, 6, 0, 1, 2, 4, 0, 1, 2, 3, 0, 1, 2, 3, 1, 0, 1, 2, 3, 4, 12, 0, 1, 2, 0, 2, 2 };
                double[] ni = { 0.0000591599780322238, -0.00185465997137856, 0.0104190510480013, 0.0059864730203859, -0.771391189901699, 1.72549765557036, -0.000467076079846526, 0.0134533823384439, -0.0808094336805495, 0.508139374365767, 0.00128584643361683, -1.63899353915435, 5.86938199318063, -2.92466667918613, -0.00614076301499537, 5.76199014049172, -12.1613320606788, 1.67637540957944, -7.44135838773463, 0.0378168091437659, 4.01432203027688, 16.0279837479185, 3.17848779347728, -3.58362310304853, -1159952.60446827, 0.199256573577909, -0.122270624794624, -19.1449143716586, -0.0150448002905284, 14.6407900162154, -3.2747778718823 };
                double pi = p / 100;
                double Sigma = s / 5.3;
                double omega = 0;
                for (int I = 0; I < 30; I++) omega = omega + ni[I] * Math.Pow(pi + 0.298, Ii[I]) * Math.Pow(Sigma - 0.816, Ji[I]);
                return omega * 0.0088;
            }

        }
        private static double _P3HS(double h, double s)
        {
            // Supplementary Release on Backward Equations ( ) , p h s for Region 3,
            // Equations as a Function of h and s for the Region Boundaries, and an Equation
            // ( ) sat , T hs for Region 4 of the IAPWS Industrial Formulation 1997 for the
            // Thermodynamic Properties of Water and Steam
            // 2004
            // Section 3 Backward Functions p(h,s), T(h,s), and v(h,s) for Region 3
            if (s < 4.41202148223476)
            {
                // Subregion 3a
                // Eq 1, Table 3, Page 8
                int[] Ii = { 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 6, 7, 8, 10, 10, 14, 18, 20, 22, 22, 24, 28, 28, 32, 32 };
                int[] Ji = { 0, 1, 5, 0, 3, 4, 8, 14, 6, 16, 0, 2, 3, 0, 1, 4, 5, 28, 28, 24, 1, 32, 36, 22, 28, 36, 16, 28, 36, 16, 36, 10, 28 };
                double[] ni = { 7.70889828326934, -26.0835009128688, 267.416218930389, 17.2221089496844, -293.54233214597, 614.135601882478, -61056.2757725674, -65127225.1118219, 73591.9313521937, -11664650591.4191, 35.5267086434461, -596.144543825955, -475.842430145708, 69.6781965359503, 335.674250377312, 25052.6809130882, 146997.380630766, 5.38069315091534E+19, 1.43619827291346E+21, 3.64985866165994E+19, -2547.41561156775, 2.40120197096563E+27, -3.93847464679496E+29, 1.47073407024852E+24, -4.26391250432059E+31, 1.94509340621077E+38, 6.66212132114896E+23, 7.06777016552858E+33, 1.75563621975576E+41, 1.08408607429124E+28, 7.30872705175151E+43, 1.5914584739887E+24, 3.77121605943324E+40 };
                double Sigma = s / 4.4;
                double eta = h / 2300;
                double pi = 0;
                for (int I = 0; I < 33; I++) pi = pi + ni[I] * Math.Pow(eta - 1.01, Ii[I]) * Math.Pow(Sigma - 0.75, Ji[I]);
                return pi * 99;
            }
            else
            {
                // Subregion 3b
                // Eq 2, Table 4, Page 8
                int[] Ii = { -12, -12, -12, -12, -12, -10, -10, -10, -10, -8, -8, -6, -6, -6, -6, -5, -4, -4, -4, -3, -3, -3, -3, -2, -2, -1, 0, 2, 2, 5, 6, 8, 10, 14, 14 };
                int[] Ji = { 2, 10, 12, 14, 20, 2, 10, 14, 18, 2, 8, 2, 6, 7, 8, 10, 4, 5, 8, 1, 3, 5, 6, 0, 1, 0, 3, 0, 1, 0, 1, 1, 1, 3, 7 };
                double[] ni = { 0.000000000000125244360717979, -0.0126599322553713, 5.06878030140626, 31.7847171154202, -391041.161399932, -0.0000000000975733406392044, -18.6312419488279, 510.973543414101, 373847.005822362, 0.0000000299804024666572, 20.0544393820342, -0.00000498030487662829, -10.230180636003, 55.2819126990325, -206.211367510878, -7940.12232324823, 7.82248472028153, -58.6544326902468, 3550.73647696481, -0.000115303107290162, -1.75092403171802, 257.98168774816, -727.048374179467, 0.000121644822609198, 0.0393137871762692, 0.00704181005909296, -82.910820069811, -0.26517881813125, 13.7531682453991, -52.2394090753046, 2405.56298941048, -22736.1631268929, 89074.6343932567, -23923456.5822486, 5687958081.29714 };
                double Sigma = s / 5.3;
                double eta = h / 2800;
                double pi = 0;
                for (int I = 0; I < 35; I++) pi = pi + ni[I] * Math.Pow(eta - 0.681, Ii[I]) * Math.Pow(Sigma - 0.792, Ji[I]);
                return 16.6 / pi;
            }
        }

        private static double _H3PT(double p, double T)
        {
            // not avalible with if 97
            // Solve function _T3PH-T=0 with half interval method.
            double ts = T + 1;
            double Low_Bound = _H1PT(p, 623.15);
            double High_Bound = _H2PT(p, _TB23P(p));
            while (true)
            {
                double hs = (Low_Bound + High_Bound) / 2;
                ts = _T3PH(p, hs);
                if (Math.Abs(T - ts) < 0.00001) return hs;
                if (ts > T) High_Bound = hs;
                else Low_Bound = hs;
            }
        }

        private static double _T3PD(double p, double rho) {
            // Not optimise
            // Solve by iteration.
            // Solve with half interval method
            double Low_Bound = _TB23P(p);
            double High_Bound = 1073.15;
            while (true) {
                double ts = (Low_Bound + High_Bound) / 2;
                double rhos = 1.0 / _V3PT(p, ts);
                if (Math.Abs(rho - rhos) < 0.000001) return ts;
                if (rhos < rho) High_Bound = ts;
                else Low_Bound = ts;
            }
        }
        #endregion
        /***********************************************************************************************************/
        #region  *2.4 Functions for region 4

        private static double _PB4T(double T) {
            //# Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //# Section 8.1 The Saturation-Pressure Equation
            //# Eq 30, Page 33
            double teta = T - 0.23855557567849 / (T - 650.17534844798);
            double a = Math.Pow(teta, 2) + 1167.0521452767 * teta - 724213.16703206;
            double b = -17.073846940092 * Math.Pow(teta, 2) + 12020.82470247 * teta - 3232555.0322333;
            double c = 14.91510861353 * Math.Pow(teta, 2) - 4823.2657361591 * teta + 405113.40542057;
            return Math.Pow(2 * c / (-b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)), 4);
        }
        /*private static double _T4P(double p)// from VBA
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // Section 8.2 The Saturation-Temperature Equation
            // Eq 31, Page 34
            double beta = Math.Pow(p, 0.25);
            double e = Math.Pow(beta, 2) - 17.073846940092 * beta + 14.91510861353;
            double f = 1167.0521452767 * Math.Pow(beta, 2) + 12020.82470247 * beta - 4823.2657361591;
            double g = -724213.16703206 * Math.Pow(beta, 2) - 3232555.0322333 * beta + 405113.40542057;
            double d = 2 * g / Math.Sqrt(-f - (Math.Pow(f, 2) - 4 * e * g));
            beta = (650.17534844798 + d - Math.Sqrt(Math.Pow(650.17534844798 + d, 2) - 4 * (-0.23855557567849 + 650.17534844798 * d))) / 2;
            return beta;
        }
        */
        private static double _T4P(double p) // from Python module
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // Section 8.2 The Saturation-Temperature Equation
            // Eq 31, Page 34

            double[] n = {0, 0.11670521452767E+04, -0.72421316703206E+06, -0.17073846940092E+02,
                0.12020824702470E+05, -0.32325550322333E+07, 0.14915108613530E+02,
                -0.48232657361591E+04, 0.40511340542057E+06, -0.23855557567849E+00,
                0.65017534844798E+03 };
            double beta = Math.Pow(p, 0.25);
            double E = Math.Pow(beta,2)+n[3]*beta+n[6];
            double F = n[1]*Math.Pow(beta, 2)+n[4]*beta+n[7];
            double G = n[2]*Math.Pow(beta, 2)+n[5]*beta+n[8];
            double D = 2*G/(-F-Math.Pow(Math.Pow(F, 2)-4*E*G, 0.5));
            return (n[10] + D - Math.Sqrt(Math.Pow(n[10] + D, 2) - 4 * (n[9] + n[10] * D)) ) / 2;
        }

        private static double _H4S(double s)
        {
            // Supplementary Release on Backward Equations ( ) , p h s for Region 3,Equations as a Function of h and s for the Region Boundaries, and an Equation( ) sat , T hs for Region 4 of the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam
            // 4 Equations for Region Boundaries Given Enthalpy and Entropy
            //  Se picture page 14
            if (-0.0001545495919 < s && s <= 3.77828134)
            {
                // hL1_s
                // Eq 3,Table 9,Page 16
                int[] Ii = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 4, 5, 5, 7, 8, 12, 12, 14, 14, 16, 20, 20, 22, 24, 28, 32, 32 };
                int[] Ji = { 14, 36, 3, 16, 0, 5, 4, 36, 4, 16, 24, 18, 24, 1, 4, 2, 4, 1, 22, 10, 12, 28, 8, 3, 0, 6, 8 };
                double[] ni = { 0.332171191705237, 0.000611217706323496, -8.82092478906822, -0.45562819254325, -0.0000263483840850452, -22.3949661148062, -4.28398660164013, -0.616679338856916, -14.682303110404, 284.523138727299, -113.398503195444, 1156.71380760859, 395.551267359325, -1.54891257229285, 19.4486637751291, -3.57915139457043, -3.35369414148819, -0.66442679633246, 32332.1885383934, 3317.66744667084, -22350.1257931087, 5739538.75852936, 173.226193407919, -0.0363968822121321, 0.000000834596332878346, 5.03611916682674, 65.5444787064505 };
                double Sigma = s / 3.8;
                double eta = 0;
                for (int I = 0; I < 27; I++) eta = eta + ni[I] * Math.Pow(Sigma - 1.09, Ii[I]) * Math.Pow(Sigma + 0.0000366, Ji[I]);


                return eta * 1700;
            }
            else if (3.77828134 < s && s <= 4.41202148223476)
            {
                // hL3_s
                // Eq 4,Table 10,Page 16
                int[] Ii = { 0, 0, 0, 0, 2, 3, 4, 4, 5, 5, 6, 7, 7, 7, 10, 10, 10, 32, 32 };
                int[] Ji = { 1, 4, 10, 16, 1, 36, 3, 16, 20, 36, 4, 2, 28, 32, 14, 32, 36, 0, 6 };
                double[] ni = { 0.822673364673336, 0.181977213534479, -0.011200026031362, -0.000746778287048033, -0.179046263257381, 0.0424220110836657, -0.341355823438768, -2.09881740853565, -8.22477343323596, -4.99684082076008, 0.191413958471069, 0.0581062241093136, -1655.05498701029, 1588.70443421201, -85.0623535172818, -31771.4386511207, -94589.0406632871, -0.0000013927384708869, 0.63105253224098 };
                double Sigma = s / 3.8;
                double eta = 0;
                for (int I = 0; I < 19; I++) eta = eta + ni[I] * Math.Pow(Sigma - 1.09, Ii[I]) * Math.Pow(Sigma + 0.0000366, Ji[I]);

                return eta * 1700;
            }
            else if (4.41202148223476 < s && s <= 5.85)
            {
                // Section 4.4 Equations ( ) 2ab " h s and ( ) 2c3b "h s for the Saturated Vapor Line
                // Page 19, Eq 5
                // hV2c3b_s(s)
                int[] Ii = { 0, 0, 0, 1, 1, 5, 6, 7, 8, 8, 12, 16, 22, 22, 24, 36 };
                int[] Ji = { 0, 3, 4, 0, 12, 36, 12, 16, 2, 20, 32, 36, 2, 32, 7, 20 };
                double[] ni = { 1.04351280732769, -2.27807912708513, 1.80535256723202, 0.420440834792042, -105721.24483466, 4.36911607493884E+24, -328032702839.753, -6.7868676080427E+15, 7439.57464645363, -3.56896445355761E+19, 1.67590585186801E+31, -3.55028625419105E+37, 396611982166.538, -4.14716268484468E+40, 3.59080103867382E+18, -1.16994334851995E+40 };
                double Sigma = s / 5.9;
                double eta = 0;
                for (int I = 0; I < 16; I++) eta = eta + ni[I] * Math.Pow(Sigma - 1.02, Ii[I]) * Math.Pow(Sigma - 0.726, Ji[I]);

                return Math.Pow(eta, 4) * 2800;
            }

            else if (5.85 < s && s < 9.155759395)
            {
                // Section 4.4 Equations ( ) 2ab " h s and ( ) 2c3b "h s for the Saturated Vapor Line
                // Page 20, Eq 6
                int[] Ii = { 1, 1, 2, 2, 4, 4, 7, 8, 8, 10, 12, 12, 18, 20, 24, 28, 28, 28, 28, 28, 32, 32, 32, 32, 32, 36, 36, 36, 36, 36 };
                int[] Ji = { 8, 24, 4, 32, 1, 2, 7, 5, 12, 1, 0, 7, 10, 12, 32, 8, 12, 20, 22, 24, 2, 7, 12, 14, 24, 10, 12, 20, 22, 28 };
                double[] ni = { -524.581170928788, -9269472.18142218, -237.385107491666, 21077015581.2776, -23.9494562010986, 221.802480294197, -5104725.33393438, 1249813.96109147, 2000084369.96201, -815.158509791035, -157.612685637523, -11420042233.2791, 6.62364680776872E+15, -2.27622818296144E+18, -1.71048081348406E+31, 6.60788766938091E+15, 1.66320055886021E+22, -2.18003784381501E+29, -7.87276140295618E+29, 1.51062329700346E+31, 7957321.70300541, 1.31957647355347E+15, -3.2509706829914E+23, -4.18600611419248E+25, 2.97478906557467E+34, -9.53588761745473E+19, 1.66957699620939E+24, -1.75407764869978E+32, 3.47581490626396E+34, -7.10971318427851E+38 };
                double Sigma1 = s / 5.21;
                double Sigma2 = s / 9.2;
                double eta = 0;
                for (int I = 0; I < 30; I++) eta = eta + ni[I] * Math.Pow(1 / Sigma1 - 0.513, Ii[I]) * Math.Pow(Sigma2 - 0.524, Ji[I]);

                return Math.Exp(eta) * 2800;
            }
            else return 0;

        }
        private static double _P4S(double s)
        {
            // Uses _H4S and wsp_PHS for the diffrent regions to determine _P4S
            double hsat = _H4S(s);
            if (-0.0001545495919 < s && s <= 3.77828134) return _P1HS(hsat, s);
            else if (3.77828134 < s && s <= 5.210887663) return _P3HS(hsat, s);
            else if (5.210887663 < s && s < 9.155759395) return _P2HS(hsat, s);
            else return 0;
        }
        private static double _H4SWP(double p)
        {
            if (0.000611657 < p && p < 22.06395) {
                double ts = _T4P(p);
                if (p < 16.529) return _H1PT(p, ts);
                else return 0;
            }
            else
            {
                // Iterate to find the the backward solution of _PS3H
                double Low_Bound = 1670.858218;
                double High_Bound = 2087.23500164864;
                while (true) {
                    double hs = (Low_Bound + High_Bound) / 2;
                    double ps = _PS3H(hs);
                    if (Math.Abs(p - ps) < 0.00001) return hs;
                    if (ps > p) High_Bound = hs;
                    else Low_Bound = hs;
                }
            }
        }


        private static double _H4SSP(double p)
        {
            if (0.000611657 < p && p < 22.06395) {
                double ts = _T4P(p);
                if (p < 16.529) return _H2PT(p, ts);
                else return 0;
            }
            else {
                // Iterate to find the the backward solution of _PS3H
                double Low_Bound = 2087.23500164864;
                double High_Bound = 2563.592004;
                while (true) {
                    double hs = (Low_Bound + High_Bound) / 2;
                    double ps = _PS3H(hs);
                    if (Math.Abs(p - ps) < 0.001) return hs;
                    if (ps < p) High_Bound = hs;
                    else Low_Bound = hs;
                }
            }
        }

        private static double _X4PH(double p, double h)
        {
            // Calculate vapour fraction from hL and hV for given p
            double h4v = _H4SSP(p);
            double h4L = _H4SWP(p);
            if (h > h4v) return 1.0;
            else if (h < h4L) return 0.0;
            else return (h - h4L) / (h4v - h4L);
        }


        private static double _X4PS(double p, double s)
        {
            double ssv; double ssL;
            if (p < 16.529) {
                ssv = _S2PT(p, _T4P(p));
                ssL = _S1PT(p, _T4P(p)); }
            else {
                ssv = _S3DT(1.0 / (_V3PH(p, _H4SSP(p))), _T4P(p));
                ssL = _S3DT(1.0 / (_V3PH(p, _H4SWP(p))), _T4P(p));
            }
            if (s < ssL) return 0.0;
            else if (s > ssv) return 1.0;
            else return (s - ssL) / (ssv - ssL);

        }
        private static double _T4HS(double h, double s)
        {
            // Supplementary Release on Backward Equations ( ) , p h s for Region 3,
            // Chapter 5.3 page 30.
            // The if 97 function is only valid for part of region4. Use iteration outsida.
            int[] Ii = { 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 5, 5, 5, 5, 6, 6, 6, 8, 10, 10, 12, 14, 14, 16, 16, 18, 18, 18, 20, 28 };
            int[] Ji = { 0, 3, 12, 0, 1, 2, 5, 0, 5, 8, 0, 2, 3, 4, 0, 1, 1, 2, 4, 16, 6, 8, 22, 1, 20, 36, 24, 1, 28, 12, 32, 14, 22, 36, 24, 36 };
            double[] ni = { 0.179882673606601, -0.267507455199603, 1.162767226126, 0.147545428713616, -0.512871635973248, 0.421333567697984, 0.56374952218987, 0.429274443819153, -3.3570455214214, 10.8890916499278, -0.248483390456012, 0.30415322190639, -0.494819763939905, 1.07551674933261, 0.0733888415457688, 0.0140170545411085, -0.106110975998808, 0.0168324361811875, 1.25028363714877, 1013.16840309509, -1.51791558000712, 52.4277865990866, 23049.5545563912, 0.0249459806365456, 2107964.67412137, 366836848.613065, -144814105.365163, -0.0017927637300359, 4899556021.00459, 471.262212070518, -82929439019.8652, -1715.45662263191, 3557776.82973575, 586062760258.436, -12988763.5078195, 31724744937.1057 };
            double pl; double ts;
            if (5.210887825 < s && s < 9.15546555571324) {
                double Sigma = s / 9.2;
                double eta = h / 2800;
                double teta = 0;
                for (int I = 0; I < 36; I++) teta = teta + ni[I] * Math.Pow(eta - 0.119, Ii[I]) * Math.Pow(Sigma - 1.07, Ji[I]);
                return teta * 550; }
            // Function psat_h
            else {
                double Low_Bound; double High_Bound;
                if (-0.0001545495919 < s && s <= 3.77828134) {
                    Low_Bound = 0.000611;
                    High_Bound = 165.291642526045;
                    while (true) {
                        pl = (Low_Bound + High_Bound) / 2;
                        ts = _T4P(pl);
                        double hL = _H1PT(pl, ts);
                        if (Math.Abs(hL - h) < 0.00001 && Math.Abs(High_Bound - Low_Bound) < 0.0001) break;
                        if (hL > h) High_Bound = pl;
                        else Low_Bound = pl;
                    }
                }
                else if (3.77828134 < s && s <= 4.41202148223476) pl = _PS3H(h);
                else if (4.41202148223476 < s && s <= 5.210887663) pl = _PS3H(h);
                else pl = 0;
                Low_Bound = 0.000611;
                High_Bound = pl;

                while (true) {
                    double ps = (Low_Bound + High_Bound) / 2;

                    // Calculate s4_ph
                    ts = _T4P(ps);
                    double xs = _X4PH(ps, h);
                    double s4v; double s4L; double v4v; double v4L;
                    if (ps < 16.529) {
                        s4v = _S2PT(ps, ts);
                        s4L = _S1PT(ps, ts); }
                    else {
                        v4v = _V3PH(ps, _H4SSP(ps));
                        s4v = _S3DT(1 / v4v, ts);
                        v4L = _V3PH(ps, _H4SWP(ps));
                        s4L = _S3DT(1 / v4L, ts); }
                    double ss = (xs * s4v + (1 - xs) * s4L);
                    if (Math.Abs(s - ss) < 0.000001 && Math.Abs(High_Bound - Low_Bound) < 0.0000001) return _T4P(ps);
                    if (ss < s) High_Bound = ps;
                    else Low_Bound = ps;
                }

            }
        }
        private static double _P4HS(double h, double s) => _PB4T(_T4HS(h, s));

        #endregion
        // ***********************************************************************************************************
        #region *2.5 Functions for region 5
        private static double _H5PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // Basic Equation for Region 5
            // Eq 32,33, Page 36, Tables 37-41
            int[] Ji0 = { 0, 1, -3, -2, -1, 2 };
            double[] ni0 = { -13.179983674201, 6.8540841634434, -0.024805148933466, 0.36901534980333, -3.1161318213925, -0.32961626538917 };
            int[] Iir = { 1, 1, 1, 2, 3 };
            int[] Jir = { 0, 1, 3, 9, 3 };
            double[] nir = { -0.00012563183589592, 0.0021774678714571, -0.004594282089991, -0.0000039724828359569, 0.00000012919228289784 };

            double tau = 1000 / T;
            double pi = p;
            double gamma0_tau = 0;
            for (int I = 0; I < 6; I++)
            { // Проверить
                gamma0_tau = gamma0_tau + ni0[I] * Ji0[I] * Math.Pow(tau, Ji0[I] - 1);
            }
            double gammar_tau = 0;
            for (int I = 0; I < 5; I++)
            { // Проверить
                gammar_tau = gammar_tau + nir[I] * Math.Pow(pi, Iir[I]) * Jir[I] * Math.Pow(tau, Jir[I] - 1);
            }

            return R * T * tau * (gamma0_tau + gammar_tau);

        }
        private static double _V5PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // Basic Equation for Region 5
            // Eq 32,33, Page 36, Tables 37-41
            int[] Ji0 = { 0, 1, -3, -2, -1, 2 };
            double[] ni0 = { -13.179983674201, 6.8540841634434, -0.024805148933466, 0.36901534980333, -3.1161318213925, -0.32961626538917 };
            int[] Iir = { 1, 1, 1, 2, 3 };
            int[] Jir = { 0, 1, 3, 9, 3 };
            double[] nir = { -0.00012563183589592, 0.0021774678714571, -0.004594282089991, -0.0000039724828359569, 0.00000012919228289784 };

            double tau = 1000 / T;
            double pi = p;
            double gamma0_pi = 1 / pi;
            double gammar_pi = 0;
            for (int I = 0; I < 5; I++) gammar_pi = gammar_pi + nir[I] * Iir[I] * Math.Pow(pi, Iir[I] - 1) * Math.Pow(tau, Jir[I]);


            return R * T / p * pi * (gamma0_pi + gammar_pi) / 1000;
        }


        private static double _U5PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // Basic Equation for Region 5
            // Eq 32,33, Page 36, Tables 37-41
            int[] Ji0 = { 0, 1, -3, -2, -1, 2 };
            double[] ni0 = { -13.179983674201, 6.8540841634434, -0.024805148933466, 0.36901534980333, -3.1161318213925, -0.32961626538917 };
            int[] Iir = { 1, 1, 1, 2, 3 };
            int[] Jir = { 0, 1, 3, 9, 3 };
            double[] nir = { -0.00012563183589592, 0.0021774678714571, -0.004594282089991, -0.0000039724828359569, 0.00000012919228289784 };

            double tau = 1000 / T;
            double pi = p;
            double gamma0_pi = 1 / pi;
            double gamma0_tau = 0;
            for (int I = 0; I < 6; I++) gamma0_tau = gamma0_tau + ni0[I] * Ji0[I] * Math.Pow(tau, Ji0[I] - 1);


            double gammar_pi = 0;
            double gammar_tau = 0;
            for (int I = 0; I < 5; I++)
            {
                gammar_pi = gammar_pi + nir[I] * Iir[I] * Math.Pow(pi, Iir[I] - 1) * Math.Pow(tau, Jir[I]);

                gammar_tau = gammar_tau + nir[I] * Math.Pow(pi, Iir[I]) * Jir[I] * Math.Pow(tau, Jir[I] - 1);
            }


            return R * T * (tau * (gamma0_tau + gammar_tau) - pi * (gamma0_pi + gammar_pi));
        }


        private static double _CP5PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // Basic Equation for Region 5
            // Eq 32,33, Page 36, Tables 37-41
            int[] Ji0 = { 0, 1, -3, -2, -1, 2 };
            double[] ni0 = { -13.179983674201, 6.8540841634434, -0.024805148933466, 0.36901534980333, -3.1161318213925, -0.32961626538917 };
            int[] Iir = { 1, 1, 1, 2, 3 };
            int[] Jir = { 0, 1, 3, 9, 3 };
            double[] nir = { -0.00012563183589592, 0.0021774678714571, -0.004594282089991, -0.0000039724828359569, 0.00000012919228289784 };

            double tau = 1000 / T;
            double pi = p;
            double gamma0_tautau = 0;
            for (int I = 0; I < 6; I++) gamma0_tautau = gamma0_tautau + ni0[I] * Ji0[I] * (Ji0[I] - 1) * Math.Pow(tau, Ji0[I] - 2);

            double gammar_tautau = 0;
            for (int I = 0; I < 5; I++) gammar_tautau = gammar_tautau + nir[I] * Math.Pow(pi, Iir[I]) * Jir[I] * (Jir[I] - 1) * Math.Pow(tau, Jir[I] - 2);


            return -R * Math.Pow(tau, 2) * (gamma0_tautau + gammar_tautau);
        }

        private static double _S5PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // Basic Equation for Region 5
            // Eq 32,33, Page 36, Tables 37-41
            int[] Ji0 = { 0, 1, -3, -2, -1, 2 };
            double[] ni0 = { -13.179983674201, 6.8540841634434, -0.024805148933466, 0.36901534980333, -3.1161318213925, -0.32961626538917 };
            int[] Iir = { 1, 1, 1, 2, 3 };
            int[] Jir = { 0, 1, 3, 9, 3 };
            double[] nir = { -0.00012563183589592, 0.0021774678714571, -0.004594282089991, -0.0000039724828359569, 0.00000012919228289784 };

            double tau = 1000 / T;
            double pi = p;
            double gamma0 = Math.Log(pi);
            double gamma0_tau = 0;
            for (int I = 0; I < 6; I++)
            {
                gamma0_tau = gamma0_tau + ni0[I] * Ji0[I] * Math.Pow(tau, Ji0[I] - 1);
                gamma0 = gamma0 + ni0[I] * Math.Pow(tau, Ji0[I]);
            }
            double gammar = 0;
            double gammar_tau = 0;
            for (int I = 0; I < 5; I++)
            {
                gammar += nir[I] * Math.Pow(pi, Iir[I]) * Math.Pow(tau, Jir[I]);
                gammar_tau += nir[I] * Math.Pow(pi, Iir[I]) * Jir[I] * Math.Pow(tau, Jir[I] - 1);
            }

            return R * (tau * (gamma0_tau + gammar_tau) - (gamma0 + gammar));
        }
        private static double _CV5PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // Basic Equation for Region 5
            // Eq 32,33, Page 36, Tables 37-41
            int[] Ji0 = { 0, 1, -3, -2, -1, 2 };
            double[] ni0 = { -13.179983674201, 6.8540841634434, -0.024805148933466, 0.36901534980333, -3.1161318213925, -0.32961626538917 };
            int[] Iir = { 1, 1, 1, 2, 3 };
            int[] Jir = { 0, 1, 3, 9, 3 };
            double[] nir = { -0.00012563183589592, 0.0021774678714571, -0.004594282089991, -0.0000039724828359569, 0.00000012919228289784 };

            double tau = 1000 / T;
            double pi = p;
            double gamma0_tautau = 0;
            for (int I = 0; I < 6; I++) gamma0_tautau += ni0[I] * (Ji0[I] - 1) * Ji0[I] * Math.Pow(tau, Ji0[I] - 2);

            double gammar_pi = 0;
            double gammar_pitau = 0;
            double gammar_pipi = 0;
            double gammar_tautau = 0;
            for (int I = 0; I < 5; I++)
            {
                gammar_pi += nir[I] * Iir[I] * Math.Pow(pi, Iir[I] - 1) * Math.Pow(tau, Jir[I]);
                gammar_pitau += nir[I] * Iir[I] * Math.Pow(pi, Iir[I] - 1) * Jir[I] * Math.Pow(tau, Jir[I] - 1);
                gammar_pipi += nir[I] * Iir[I] * (Iir[I] - 1) * Math.Pow(pi, Iir[I] - 2) * Math.Pow(tau, Jir[I]);
                gammar_tautau += nir[I] * Math.Pow(pi, Iir[I]) * Jir[I] * (Jir[I] - 1) * Math.Pow(tau, Jir[I] - 2);
            }

            return R * (Math.Pow(tau, 2) * -(gamma0_tautau + gammar_tautau)
                - (1 + pi * gammar_pi - tau * pi * gammar_pitau) / (1 - Math.Pow(pi, 2) * gammar_pipi));
        }
        private static double _W5PT(double p, double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            // Basic Equation for Region 5
            // Eq 32,33, Page 36, Tables 37-41
            int[] Ji0 = { 0, 1, -3, -2, -1, 2 };
            double[] ni0 = { -13.179983674201, 6.8540841634434, -0.024805148933466, 0.36901534980333, -3.1161318213925, -0.32961626538917 };
            int[] Iir = { 1, 1, 1, 2, 3 };
            int[] Jir = { 0, 1, 3, 9, 3 };
            double[] nir = { -0.00012563183589592, 0.0021774678714571, -0.004594282089991, -0.0000039724828359569, 0.00000012919228289784 };

            double tau = 1000 / T;
            double pi = p;
            double gamma0_tautau = 0;
            for (int I = 0; I < 6; I++) gamma0_tautau += ni0[I] * (Ji0[I] - 1) * Ji0[I] * Math.Pow(tau, Ji0[I] - 2);


            double gammar_pi = 0;
            double gammar_pitau = 0;
            double gammar_pipi = 0;
            double gammar_tautau = 0;
            for (int I = 0; I < 5; I++)
            {
                gammar_pi += nir[I] * Iir[I] * Math.Pow(pi, Iir[I] - 1) * Math.Pow(tau, Jir[I]);
                gammar_pitau += nir[I] * Iir[I] * Math.Pow(pi, Iir[I] - 1) * Jir[I] * Math.Pow(tau, Jir[I] - 1);
                gammar_pipi += nir[I] * Iir[I] * (Iir[I] - 1) * Math.Pow(pi, Iir[I] - 2) * Math.Pow(tau, Jir[I]);
                gammar_tautau += nir[I] * Math.Pow(pi, Iir[I]) * Jir[I] * (Jir[I] - 1) * Math.Pow(tau, Jir[I] - 2);
            }
            return Math.Sqrt(1000 * R * T * (1 + 2 * pi * gammar_pi + Math.Pow(pi, 2) * Math.Pow(gammar_pi, 2)) / ((1 - Math.Pow(pi, 2) * gammar_pipi) + Math.Pow(1 + pi * gammar_pi - tau * pi * gammar_pitau, 2) / (Math.Pow(tau, 2) * (gamma0_tautau + gammar_tautau))));
        }

        private static double _T5PH(double p, double h)
        {
            // Solve with half interval method
            double Low_Bound = 1073.15;
            double High_Bound = 2273.15;
            while (true) {
                double ts = (Low_Bound + High_Bound) / 2;
                double hs = _H5PT(p, ts);
                if (Math.Abs(h - hs) < 0.00001) return ts;
                if (hs > h) High_Bound = ts;
                else Low_Bound = ts;
            }
        }
        private static double _T5PS(double p, double s)
        {
            // Solve with half interval method
            double Low_Bound = 1073.15;
            double High_Bound = 2273.15;
            while (true) {
                double ts = (Low_Bound + High_Bound) / 2;
                double ss = _S5PT(p, ts);
                if (Math.Abs(s - ss) < 0.00000001) return ts;
                if (ss > s) High_Bound = ts;
                else Low_Bound = ts;
            }
        }
        private static double _T5PD(double p, double rho)
        {
            // Solve by iteration. Observe that fo low temperatures this equation has 2 solutions.
            // Solve with half interval method
            double Low_Bound = 1073.15;
            double High_Bound = 2073.15;
            while (true) {
                double ts = (Low_Bound + High_Bound) / 2;
                double rhos = 1.0 / _V2PT(p, ts);
                if (Math.Abs(rho - rhos) < 0.000001) return ts;
                if (rhos < rho) High_Bound = ts;
                else Low_Bound = ts;
            }
        }
        #endregion
        // ***********************************************************************************************************
        // *3 Region Selection
        // ***********************************************************************************************************
        # region *3.1 Regions as a function of pT
        private static int _Region_PT(double p, double T)
        {
            if (1073.15 < T && T < 2273.15 && 0.000611 < p && p < 10) return 5;
            if (273.15 < T && T <= 1073.15 && 0.000611 < p && p <= 100) {
                if (T > 623.15) {
                    if (p > _PB23T(T)) return 3;
                    else return 2;
                }
                else {
                    if (p > _PB4T(T)) return 1;
                    else return 2;
                }
            }
            return 0;  // '**Error, Outside valid area;
        }

        #endregion
        // ***********************************************************************************************************
        #region *3.2 Regions as a function of ph
        private static int _Region_PH(double p, double h)
        {
            // Check if outside pressure limits
            if (p < 0.000611657 || p > 100) return 0;


            // Check if outside low h.
            if (h < 0.963 * p + 2.2) { // 'Linear adaption to _H1PT()+2 to speed up calcualations.
                if (h < _H1PT(p, 273.15)) return 0;
            }

            if (p < 16.5292) { // 'Bellow region 3,Check  region 1,4,2,5
                               // Check Region 1
                double ts = _T4P(p);
                double hL = 109.6635 * Math.Log(p) + 40.3481 * p + 734.58; // 'Approximate function for wsp_HSWP;

                if (Math.Abs(h - hL) < 100) { // 'if approximate is not god enough use real function
                    hL = _H1PT(p, ts);
                }

                if (h <= hL) return 1;

                // Check Region 4
                double hV = 45.1768 * Math.Log(p) - 20.158 * p + 2804.4;  // 'Approximate function for wsp_HSSP;
                if (Math.Abs(h - hL) < 50) hV = _H2PT(p, ts); // 'if approximate is not god enough use real function


                if (h < hV) return 4;

                // Check upper limit of region 2 Quick Test
                if (h < 4000) return 2;
                // Check region 2 (Real value)
                double h_45 = _H2PT(p, 1073.15);
                if (h <= h_45) return 2;
                // Check region 5
                if (p > 10) return 0;
                double h_5u = _H5PT(p, 2273.15);
                if (h < h_5u) return 5;
            }
            else {  // 'For p>16.5292
                    // Check if in region1
                if (h < _H1PT(p, 623.15)) return 1;
                // Check if in region 3 or 4 (Bellow Reg 2)
                if (h < _H2PT(p, _TB23P(p))) {
                    // Region 3 or 4
                    if (p > _PS3H(h)) return 3;
                    else return 4;
                }
                // Check if region 2
                if (h < _H2PT(p, 1073.15)) return 2;
            }
            return 0;
        }
        private static int  _Region_PH1(double P, double h)
        {
    /*Region definition for input P y h

    Parameters
    ----------
    P : float
        Pressure, [MPa]
    h : float
        Specific enthalpy, [kJ/kg]

    Returns
    -------
    region : float
        IAPWS-97 region code

    References
    ----------
    Wagner, W; Kretzschmar, H-J: International Steam Tables: Properties of
    Water and Steam Based on the Industrial Formulation IAPWS-IF97; Springer,
    2008; doi: 10.1007/978-3-540-74234-0. Fig. 2.5
    */
        
        int region = 0;
        if (PMIN <= P&&P <= PST_623){
            double h14 = _H1PT(P, _TSP(P));
            double h24 = _H2PT(P, _TSP(P));
            double h25 = _H2PT(P, 1073.15);
            double hmin = _H1PT(P, 273.15);
            double hmax = _H5PT(P, 2273.15);
            if (hmin <= h&&h <= h14)                   region = 1;
            else if (h14 < h&&h < h24)                 region = 4;
            else if (h24 <= h&&h <= h25)               region = 2;
            else if (h25 < h&&h <= hmax)               region = 5;
        }
        else if (PST_623 < P&&P < pc){
            double hmin = _H1PT(P, 273.15);
            double h13 = _H1PT(P, 623.15);
            double h32 = _H2PT(P, _TB23P(P));
            double h25 = _H2PT(P, 1073.15);
            double hmax = _H5PT(P, 2273.15);
            if (hmin <= h&&h <= h13)                   region = 1;
            else if (h13 < h&&h < h32){
                    double p34;
                    try { p34 = _PSH(h); } catch { p34 = pc; }
                    if (P < p34) region = 4;
                    else region = 3;
                }
            else if (h32 <= h&&h <= h25)               region = 2;
            else if (h25 < h&&h <= hmax)               region = 5;
            }
        else if (pc <= P&&P <= 100){
            double hmin = _H1PT(P, 273.15);
            double h13 = _H1PT(P, 623.15);
            double h32 = _H2PT(P, _TB23P(P));
            double h25 = _H2PT(P, 1073.15);
            double hmax = _H5PT(P, 2273.15);
                if (hmin <= h && h <= h13)              region = 1;
                else if (h13 < h && h < h32)            region = 3;
                else if (h32 <= h && h <= h25)          region = 2;
                else if (P <= 50 && h25 <= h && h <= hmax) region = 5;
            }
        return region;
        }
        #endregion
        // ***********************************************************************************************************
        #region *3.3 Regions as a function of ps
        private static int _Region_PS1(double p, double s) // Из VBA проекта
        {
            if (p < 0.000611657 || p > 100 || s < 0 || s > _S5PT(p, 2273.15)) return 0;

            // Check region 5
            if (s > _S2PT(p, 1073.15)) {
                if (p <= 10) return 5;
                else return 0;
            }

            // Check region 2
            double ss;
            if (p > 16.529) ss = _S2PT(p, _TB23P(p));  // 'Between 5.047 and 5.261. Use to speed up!;
            else ss = _S2PT(p, _T4P(p));
            if (s > ss) return 2;

            // Check region 3
            ss = _S1PT(p, 623.15);
            if (p > 16.529 && s > ss) {
                if (p > _PS3S(s)) return 3;
                else return 4;
            }
            // Check region 4 (Not inside region 3)
            if (p < 16.529 && s > _S1PT(p, _T4P(p))) return 4;

            // Check region 1
            if (p > 0.000611657 && s > _S1PT(p, 273.15)) return 1;
            return 1;  // Надо проверить
        }

        private static int _Region_PS(double p, double s) // Из Python модуля
        {
            int region = 0;
            if (0.000611212677444 <= p && p <= 16.5291642526){
                double smin = _S1PT(p, 273.15);
                double s14 = _S1PT(p, _TSP(p));
                double s24 = _S2PT(p, _TSP(p));
                double s25 = _S2PT(p, 1073.15);
                double smax = _S5PT(p, 2273.15);
                if (smin <= s && s <= s14)                      region = 1;
                else if (s14 < s && s < s24)                    region = 4;
                else if (s24 <= s && s <= s25)                  region = 2;
                else if (s25 < s && s <= smax)                  region = 5;
                }
            else if (16.5291642526 < p && p < pc){
                    double smin = _S1PT(p, 273.15);
                    double s13 = _S1PT(p, 623.15);
                    double s32 = _S2PT(p, _TB23P(p));
                    double s25 = _S2PT(p, 1073.15);
                    double smax = _S5PT(p, 2273.15);
                if (smin <= s && s <= s13)                      region = 1;
                else if (s13 < s && s < s32){
                        double p34;
                    try{p34 = _PSS(s);}
                    catch {p34 = pc;}
                    if (p < p34)                                region = 4;
                    else                                        region = 3;
                        }
                else if (s32 <= s && s <= s25)                  region = 2;
                else if (s25 < s && s <= smax)                  region = 5;
                }
            else if (pc <= p && p <= 100){
                    double smin = _S1PT(p, 273.15);
                    double s13 = _S1PT(p, 623.15);
                    double s32 = _S2PT(p, _TB23P(p));
                    double s25 = _S2PT(p, 1073.15);
                    double smax = _S5PT(p, 2273.15);
                    if (smin <= s && s <= s13) region = 1;
                    else if (s13 < s && s < s32) region = 3;
                    else if (s32 <= s && s <= s25) region = 2;
                    else if (p <= 50 && s25 <= s && s <= smax) region = 5;
                }
            return region;
        }
       
        #endregion
        // ***********************************************************************************************************
        #region *3.4 Regions as a function of hs
        private static int _Region_HS(double h, double s)
        {
            if (s < -0.0001545495919) return 0;
            // Check linear adaption to p=0.000611. if bellow region 4.
            double hMin = (((-0.0415878 - 2500.89262) / (-0.00015455 - 9.155759)) * s);
            double Tmin; double TMax; double hMax; double vmax; double hV;
            if (s < 9.155759395 && h < hMin) return 0;

            // ******Kolla 1 eller 4. (+liten bit цver B13)
            if (-0.0001545495919 <= s && s <= 3.77828134) {
                if (h < _H4S(s)) return 4;

                if (s < 3.397782955) {  // '100MPa line is limiting
                    TMax = _T1PS(100, s);
                    hMax = _H1PT(100, TMax);
                    if (h < hMax) return 1;
                    else return 0;
                }
                else
                { // The point is either in region 4,1,3. Check B23
                    double hB = _HB13S(s);
                    if (h < hB) return 1;
                    TMax = _T3PS(100, s);
                    vmax = _V3PS(100, s);
                    hMax = _H3DT(1 / vmax, TMax);
                    if (h < hMax) return 3;
                    else return 0;
                }

            }
            // ******Kolla region 2 eller 4. (Цvre delen av omrеde b23-> max)
            if (5.260578707 <= s && s <= 11.9212156897728) {
                if (s > 9.155759395) { //'Above region 4
                    Tmin = _T2PS(0.000611, s);
                    hMin = _H2PT(0.000611, Tmin);                // Function adapted to h(1073.15,s)
                    hMax = -0.07554022 * Math.Pow(s, 4) + 3.341571 * Math.Pow(s, 3) - 55.42151 * Math.Pow(s, 2) + 408.515 * s + 3031.338;
                    if (h > hMin && h < hMax) return 2;
                    else return 0;
                }
                hV = _H4S(s);

                if (h < hV) return 4;  //'Region 4. Under region 3.

                if (s < 6.04048367171238)
                {
                    TMax = _T2PS(100, s);
                    hMax = _H2PT(100, TMax);
                }
                else {
                    // Function adapted to h(1073.15,s)
                    hMax = -2.988734 * Math.Pow(s, 4) + 121.4015 * Math.Pow(s, 3) - 1805.15 * Math.Pow(s, 2) + 11720.16 * s - 23998.33;
                }
                if (h < hMax) return 2;  //'Region 2. Цver region 4.
                else return 0;
            }
            // Kolla region 3 eller 4. Under kritiska punkten.
            if (s >= 3.77828134 && s <= 4.41202148223476) {
                double hL = _H4S(s);
                if (h < hL) return 4;

                TMax = _T3PS(100, s);
                vmax = _V3PS(100, s);
                hMax = _H3DT(1 / vmax, TMax);
                if (h < hMax) return 3;
                else return 0;
            }
            // Kolla region 3 eller 4 frеn kritiska punkten till цvre delen av b23
            if (s >= 4.41202148223476 && s <= 5.260578707) {
                hV = _H4S(s);
                if (h < hV) return 4;
                // Kolla om vi дr under b23 giltighetsomrеde.
                if (s <= 5.048096828) {
                    TMax = _T3PS(100, s);
                    vmax = _V3PS(100, s);
                    hMax = _H3DT(1 / vmax, TMax);
                    if (h < hMax) return 3;
                    else return 0;
                }
                else {//'Inom omrеdet fцr B23 i s led.
                    if (h > 2812.942061) { //'Ovanfцr B23 i h_led
                        if (s > 5.09796573397125) {
                            TMax = _T2PS(100, s);

                            hMax = _H2PT(100, TMax);

                            if (h < hMax) return 2;
                            else return 0;
                        }
                    }
                    else return 0;

                    if (h < 2563.592004) return 3;  //'Nedanfцr B23 i h_led men vi har redan kollat ovanfцr hV2c3b

                    // Vi дr inom b23 omrеdet i bеde s och h led.
                    double Tact = _TB23HS(h, s);
                    double pact = _P2HS(h, s);
                    double pBound = _PB23T(Tact);

                    if (pact > pBound) return 3;
                    else return 2;
                }
            }
            return 0;
        }
        /*
        private static int _Region_HS(double h, double s){
    """Region definition for input h and s

    Parameters
    ----------
    h : float
        Specific enthalpy, [kJ/kg]
    s : float
        Specific entropy, [kJ/kgK]

    Returns
    -------
    region : float
        IAPWS-97 region code
    >>> _Region_HS(7376.0, 10.9)
    5

    References
    ----------
    Wagner, W; Kretzschmar, H-J: International Steam Tables: Properties of
    Water and Steam Based on the Industrial Formulation IAPWS-IF97; Springer,
    2008; doi: 10.1007/978-3-540-74234-0. Fig. 2.14
    """
    int region = 0;
    double s13 = 3.3977829547018907;//  # _PropsR1_PT(100, 623.15)["s"]
    double s13s = 3.7782813395443475;//  # _PropsR1_PT( PST_623, 623.15)["s"]
    double sTPmax = 6.040483671712382;//  # _PropsR2_PT(100, 1073.15)["s"]
    double s2ab = 7.85234039987851;//  # _PropsR2_PT(4, 1073.15)["s"]

    //# Left point in h-s plot
    double smin = -0.00858228709261889;//  # _PropsR1_PT(100, 273.15)["s"]
    //# hmin = -0.04158782598765377  # _PropsR1_PT(PMIN, 273.15)["h"]

    //# Right point in h-s plot
    //# hmax = 4160.660928250124  # _PropsR2_PT(PMIN, 1073.15)["h"]
    double smax = 11.921055068613795  # _PropsR2_PT(PMIN, 1073.15)["s"]

    //# Region 4 left and right point
    //# _sL = _PropsR1_PT(PMIN, 273.15)
    double h4l = -0.04158782598765377;//  # _sL["h"]  # _PropsR1_PT(PMIN, 273.15)["h"]
    double s4l = -0.00015454959194117582;//  # _sL["s"]  # _PropsR1_PT(PMIN, 273.15)["s"]
    //# _sV = _PropsR2_PT(PMIN, 273.15)
    double h4v = 2500.8926178171714;//  # _sV["h"]  # _PropsR2_PT(PMIN, 273.15)["h"]
    double s4v = 9.155759395224662;//  # _sV["s"]  # _PropsR2_PT(PMIN, 273.15)["s"]

    if (smin <= s <= s13){
        hmin = h4l+(s-s4l)/(s4v-s4l)*(h4v-h4l)
        hs = _HB14S(s)
        T = _T1PS(100, s)-0.0218
        hmax = _H1PT(100, T)  # _PropsR1_PT(100, T)["h"]
        if (hmin <= h < hs)            region = 4;
        else if (hs <= h <= hmax)            region = 1;
}
    else if (s13 < s <= s13s){
        double hmin = h4l+(s-s4l)/(s4v-s4l)*(h4v-h4l);
        double hs = _HB14S(s);
        double h13 = _HB13S(s);
        double v = _V3PS(100, s)*(1+9.6e-5);
        double T = _T3PS(100, s)-0.0248;
        double hmax = _H3DT(1./v, T);//  # _PropsR3_DT(1./v, T)["h"]
        if (hmin <= h < hs)            region = 4;
        else if (hs <= h < h13)            region = 1;
        else if (h13 <= h <= hmax)            region = 3;
}
    else if (s13s < s <= SC){
        double hmin = h4l+(s-s4l)/(s4v-s4l)*(h4v-h4l);
        double hs = _HB43aS(s);
        double v = _V3PS(100, s)*(1+9.6e-5);
        double T = _T3PS(100, s)-0.0248;
        double hmax = _H3DT(1/v, T);//  # _PropsR3_DT(1/v, T)["h"]
        if (hmin <= h < hs)            region = 4;
        else if (hs <= h <= hmax)            region = 3;
}
    else if (SC < s < 5.049096828){
        double hmin = h4l+(s-s4l)/(s4v-s4l)*(h4v-h4l);
        double hs = _HB42c3bS(s);
        double v = _V3PS(100, s)*(1+9.6e-5);
        double T = _T3PS(100, s)-0.0248;
        double hmax = _H3DT(1/v, T);//  # _PropsR3_DT(1/v, T)["h"]
        if (hmin <= h < hs)            region = 4;
        else if (hs <= h <= hmax)            region = 3;
}
    else if (5.049096828 <= s < 5.260578707){
        //# Specific zone with 2-3 boundary in s shape
        double hmin = h4l+(s-s4l)/(s4v-s4l)*(h4v-h4l);
        double hs = _HB42c3bS(s);
        double h23max = 2812.942060600415;//  # _H2PT(100, 863.15)  # _PropsR2_PT(100, 863.15)["h"]
        double h23min = 2563.5920038889335;//  # _H2PT(PST_623, 623.15)  # _PropsR2_PT(PST_623, 623.15)["h"]
        double T = _T2PS(100, s)-0.019;
        double hmax = _H2PT(100, T);//  # _PropsR2_PT(100, T)["h"]

        if (hmin <= h < hs)            region = 4;
        else if (hs <= h < h23min)            region = 3;
        else if (h23min <= h < h23max){
            if (__P2cHS(h, s) <= _PB23T(_TB23HS(h, s)))                region = 2;
            else                region = 3;
            }
        else if (h23max <= h <= hmax)            region = 2;
}
    else if (5.260578707 <= s < 5.85){
        double hmin = h4l+(s-s4l)/(s4v-s4l)*(h4v-h4l);
        double hs = _HB42c3bS(s);
        double T = _T2PS(100, s)-0.019;
        double hmax = _H2PT(100, T);//  # _PropsR2_PT(100, T)["h"]
        if (hmin <= h < hs)            region = 4;
        else if (hs <= h <= hmax)            region = 2;
}
    else if (5.85 <= s < sTPmax){
        double hmin = h4l+(s-s4l)/(s4v-s4l)*(h4v-h4l);
        double hs = _HB42abS(s);
        double T = _T2PS(100, s)-0.019;
        double hmax = _H2PT(100, T);//  # _PropsR2_PT(100, T)["h"]
        if (hmin <= h < hs)            region = 4;
        else if (hs <= h <= hmax)            region = 2;
}
    else if (sTPmax <= s < s2ab){
        double hmin = h4l+(s-s4l)/(s4v-s4l)*(h4v-h4l);
        double hs = _HB42abS(s);
        double P = _P2HS(h, s);
        double hmax = _H2PT(P, 1073.15);//  # _PropsR2_PT(P, 1073.15)["h"]
        if (hmin <= h < hs)            region = 4;
        else if (hs <= h <= hmax)            region = 2;
}
    else if (s2ab <= s < s4v){
        double hmin = h4l+(s-s4l)/(s4v-s4l)*(h4v-h4l);
        double hs = _HB42abS(s);
        double P = _P2HS(h, s);
        double hmax = _H2PT(P, 1073.15);//  # _PropsR2_PT(P, 1073.15)["h"]
        if (hmin <= h < hs)            region = 4;
        else if (hs <= h <= hmax)            region = 2;
}
    else if (s4v <= s <= smax){
        double hmin = 2500.8926178171714;//  # _H2PT(PMIN, 273.15)  # _PropsR2_PT(PMIN, 273.15)["h"]
        double P = __P2aHS(h, s);
        double hmax = _H2PT(P, 1073.15);//  # _PropsR2_PT(P, 1073.15)["h"]
        if (PMIN <= P <= 100 and hmin <= h <= hmax)            region = 2;
}
    # Check region 5
    # 6.522657387596356=_S5PT(50, 1073.15), 13.904956083429227=_S5PT(PMIN, 2273.15)
    # 3926.0501400717794=_H5PT(50, 1073.15), 7376.980263598507=_H5PT(PMIN, 2273.15)
    if (region==0 and \
            6.522657387596356 < s <= 13.904956083429227 \
            and 3926.0501400717794 < h <= 7376.980263598507){
        def funcion(par):
            return (_H5PT(par[0], par[1])-h,
                    _S5PT(par[0], par[1])-s)
        P, T = fsolve(funcion, [1, 1400])
        if (1073.15 < T <= 2273.15 and PMIN <= P <= 50)            region = 5;
    }

    return region;
    }
            */
        #endregion
        // ***********************************************************************************************************
        # region *3.5 Regions as a function of p and rho
        private static int _Region_PD(double p, double rho)
        {
            double v = 1 / rho;
            if (p < 0.000611657 || p > 100) return 0;
            else if (10 > p && p < 16.5292) return 0; // Above region 5

            if (p < 16.5292) { // Bellow region 3, Check region 1,4,2
                if (v < _V1PT(p, 273.15)) return 0; // Observe that this is not actually min of v. not valid Water of 4°C is ligther.

                if (v <= _V1PT(p, _T4P(p))) return 1;

                if (v < _V2PT(p, _T4P(p))) return 4;

                if (v <= _V2PT(p, 1073.15)) return 2;

                if (v <= _V5PT(p, 2073.15)) return 5;
            }
            else { // 'Check region 1,3,4,3,2 (Above the lowest point of region 3.)
                if (v < _V1PT(p, 273.15)) return 0; // 'Observe that this is not actually min of v. not valid Water of 4°C is ligther.

                if (v < _V1PT(p, 623.15)) return 1;

                // Check if in region 3 or 4 (Bellow Reg 2)
                if (v < _V2PT(p, _TB23P(p)))
                {
                    // Region 3 or 4
                    if (p > 22.064) return 3; //'Above region 4

                    if (v < _V3PH(p, _H4SWP(p)) || v > _V3PH(p, _H4SSP(p))) return 3; //'Uses iteration!!
                    else return 4;
                }
                // Check if region 2
                if (v < _V2PT(p, 1073.15)) return 2;
            }
            return 0;
        }

        #endregion
        // ***********************************************************************************************************
        // *4 Region Borders
        // ***********************************************************************************************************
        // ***********************************************************************************************************
        # region *4.1 Boundary between region 2 and 3.
        private static double _PB23T(double T)
        {
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam
            // 1997
            // Section 4 Auxiliary Equation for the Boundary between Regions 2 and 3
            // Eq 5, Page 5
            return 348.05185628969 - 1.1671859879975 * T + 0.0010192970039326 * Math.Pow(T, 2);
        }


        private static double _TB23P(double p)
        {
            /*
            >>> _TB23P(20)
            649.7847025009888
            >>> _PB23T(649.7847025009888)
            20.000000000017565
            */
            // Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam
            // 1997
            // Section 4 Auxiliary Equation for the Boundary between Regions 2 and 3
            // Eq 6, Page 6
            return 572.54459862746 + Math.Sqrt((p - 13.91883977887) / 0.0010192970039326);
        }

        #endregion
        // ***********************************************************************************************************
        # region *4.2 Region 3. pSat=F(h) and pSat=F(s)
        private static double _PS3H(double h)
        {
            // Revised Supplementary Release on Backward Equations for the Functions T(p,h), v(p,h) and T(p,s), v(p,s) for Region 3 of the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam
            // 2004
            // Section 4 Boundary Equations psat(h) and psat(s) for the Saturation Lines of Region 3
            // Se pictures Page 17, Eq 10, Table 17, Page 18
            int[] Ii = { 0, 1, 1, 1, 1, 5, 7, 8, 14, 20, 22, 24, 28, 36 };
            int[] Ji = { 0, 1, 3, 4, 36, 3, 0, 24, 16, 16, 3, 18, 8, 24 };
            double[] ni = { 0.600073641753024, -9.36203654849857, 24.6590798594147, -107.014222858224, -91582131580576.8, -8623.32011700662, -23.5837344740032, 2.52304969384128E+17, -3.89718771997719E+18, -3.33775713645296E+22, 35649946963.6328, -1.48547544720641E+26, 3.30611514838798E+18, 8.13641294467829E+37 };
            double hs = h / 2600;
            double ps = 0;
            for (int I = 0; I < 14; I++) ps = ps + ni[I] * Math.Pow(hs - 1.02, Ii[I]) * Math.Pow(hs - 0.608, Ji[I]);

            return ps * 22;
        }

        private static double _PS3S(double s)
        {
            int[] Ii = { 0, 1, 1, 4, 12, 12, 16, 24, 28, 32 };
            int[] Ji = { 0, 1, 32, 7, 4, 14, 36, 10, 0, 18 };
            double[] ni = { 0.639767553612785, -12.9727445396014, -2.24595125848403E+15, 1774667.41801846, 7170793495.71538, -3.78829107169011E+17, -9.55586736431328E+34, 1.87269814676188E+23, 119254746466.473, 1.10649277244882E+36 };
            double sigma = s / 5.2;
            double pi = 0;
            for (int I = 0; I < 10; I++) pi += ni[I] * Math.Pow(sigma - 1.03, Ii[I]) * Math.Pow(sigma - 0.699, Ji[I]);
            return pi * 22;
        }

        #endregion
        // ***********************************************************************************************************
        # region 4.3 Region boundary 1to3 and 3to2 as a functions of s
        private static double _HB13S(double s)
        {
            // Supplementary Release on Backward Equations ( ) , p h s for Region 3,
            // Chapter 4.5 page 23.
            int[] Ii = { 0, 1, 1, 3, 5, 6 };
            int[] Ji = { 0, -2, 2, -12, -4, -3 };
            double[] ni = { 0.913965547600543, -0.0000430944856041991, 60.3235694765419, 1.17518273082168E-18, 0.220000904781292, -69.0815545851641 };
            double sigma = s / 3.8;
            double eta = 0;
            for (int I = 0; I < 6; I++) eta += ni[I] * Math.Pow(sigma - 0.884, Ii[I]) * Math.Pow(sigma - 0.864, Ji[I]);

            return eta * 1700;
        }

        private static double _TB23HS(double h, double s)
        {
            // Supplementary Release on Backward Equations ( ) , p h s for Region 3,
            // Chapter 4.6 page 25.
            int[] Ii = { -12, -10, -8, -4, -3, -2, -2, -2, -2, 0, 1, 1, 1, 3, 3, 5, 6, 6, 8, 8, 8, 12, 12, 14, 14 };
            int[] Ji = { 10, 8, 3, 4, 3, -6, 2, 3, 4, 0, -3, -2, 10, -2, -1, -5, -6, -3, -8, -2, -1, -12, -1, -12, 1 };
            double[] ni = { 0.00062909626082981, -0.000823453502583165, 0.0000000515446951519474,
                            -1.17565945784945, 3.48519684726192, -0.00000000000507837382408313,
                          -2.84637670005479, -2.36092263939673, 6.01492324973779, 1.48039650824546,
                          0.000360075182221907, -0.0126700045009952, -1221843.32521413, 0.149276502463272,
                          0.698733471798484, -0.0252207040114321, 0.0147151930985213, -1.08618917681849,
                          -0.000936875039816322, 81.9877897570217, -182.041861521835, 0.00000261907376402688,
                          -29162.6417025961, 0.0000140660774926165, 7832370.62349385};
            double sigma = s / 5.3;
            double eta = h / 3000;
            double teta = 0;
            for (int I = 0; I < 25; I++) teta += ni[I] * Math.Pow(eta - 0.727, Ii[I]) * Math.Pow(sigma - 0.864, Ji[I]);

            return teta * 900;
        }

        private static double _PSH(double h){
            /*"""Define the saturated line, P=f(h) for region 3

            Parameters
            ----------
            h : float
                Specific enthalpy, [kJ/kg]

            Returns
            -------
            P : float
                Pressure, [MPa]

            Notes
            ------
            Raise :class:`NotImplementedError` if input isn't in limit:

                * h'(623.15K) ≤ h ≤ h''(623.15K)

            References
            ----------
            IAPWS, Revised Supplementary Release on Backward Equations for the
            Functions T(p,h), v(p,h) and T(p,s), v(p,s) for Region 3 of the IAPWS
            Industrial Formulation 1997 for the Thermodynamic Properties of Water and
            Steam, http://www.iapws.org/relguide/Supp-Tv%28ph,ps%293-2014.pdf, Eq 10

            Examples
            --------
            >>> _PSH(1700)
            17.24175718
            >>> _PSH(2400)
            20.18090839
            """*/
            //# Check input parameters
            double hmin_Ps3 = 1670.8582182746425;  //# _H1PT(PST_623, 623.15)
            double hmax_Ps3 = 2563.5920038889335;  //# _H2PT(PST_623, 623.15)
            
            if (h < hmin_Ps3 || h > hmax_Ps3) return 0;

            double nu = h/2600;
            int[] I = {0, 1, 1, 1, 1, 5, 7, 8, 14, 20, 22, 24, 28, 36};
            int[] J = {0, 1, 3, 4, 36, 3, 0, 24, 16, 16, 3, 18, 8, 24};
            double[] n = {0.600073641753024, -0.936203654849857e1, 0.246590798594147e2,
                 -0.107014222858224e3, -0.915821315805768e14, -0.862332011700662e4,
                 -0.235837344740032e2, 0.252304969384128e18, -0.389718771997719e19,
                 -0.333775713645296e23, 0.356499469636328e11, -0.148547544720641e27,
                 0.330611514838798e19, 0.813641294467829e38};

            double suma = 0;
            for (int k=0;k<15;k++){suma += n[k] * Math.Pow(nu-1.02, I[k]) * Math.Pow(nu-0.608, J[k]);}
            return 22*suma;
            }
        
   

        #endregion
        // ***********************************************************************************************************
        // *5 Transport properties
        // ***********************************************************************************************************
        #region *5.1 Viscosity (IAPWS formulation 1985, Revised 2003)
        // ***********************************************************************************************************
        private static double _DVPT(double p, double T)
        {
            double[] h0 = { 0.5132047, 0.3205656, 0, 0, -0.7782567, 0.1885447 };
            double[] h1 = { 0.2151778, 0.7317883, 1.241044, 1.476783, 0, 0 };
            double[] h2 = { -0.2818107, -1.070786, -1.263184, 0, 0, 0 };
            double[] h3 = { 0.1778064, 0.460504, 0.2340379, -0.4924179, 0, 0 };
            double[] h4 = { -0.0417661, 0, 0, 0.1600435, 0, 0 };
            double[] h5 = { 0, -0.01578386, 0, 0, 0, 0 };
            double[] h6 = { 0, 0, 0, -0.003629481, 0, 0 };
            // Check valid area
            if (T > 900 + 273.15
            || (T > 600 + 273.15 && p > 300)
            || (T > 150 + 273.15 && p > 350)
            || p > 500) return 0;
            // Calculate density.
            double rho = 1/_DPT(p, T);
            if (rho == 0) return 0;

            double rhos = rho / 317.763;
            double ts = T / 647.226;
            double ps = p / 22.115;
            double sm = 0;
            for (int I = 0; I < 6; I++)
            {
                sm +=
              +h0[I] * Math.Pow(1 / ts - 1, I)
              + h1[I] * Math.Pow(1 / ts - 1, I) * Math.Pow(rhos - 1, 1)
              + h2[I] * Math.Pow(1 / ts - 1, I) * Math.Pow(rhos - 1, 2)
              + h3[I] * Math.Pow(1 / ts - 1, I) * Math.Pow(rhos - 1, 3)
              + h4[I] * Math.Pow(1 / ts - 1, I) * Math.Pow(rhos - 1, 4)
              + h5[I] * Math.Pow(1 / ts - 1, I) * Math.Pow(rhos - 1, 5)
              + h6[I] * Math.Pow(1 / ts - 1, I) * Math.Pow(rhos - 1, 6);
            }
            double my0 = Math.Sqrt(ts) / (1 + 0.978197 / ts + 0.579829 / Math.Pow(ts, 2) - 0.202354 / Math.Pow(ts, 3));
            double my1 = Math.Exp(rhos * sm);
            double mys = my0 * my1;
            return mys * 0.000055071;
        }

        private static double _DVPH(double p, double h)
        {
            double[] h0 = { 0.5132047, 0.3205656, 0, 0, -0.7782567, 0.1885447 };
            double[] h1 = { 0.2151778, 0.7317883, 1.241044, 1.476783, 0, 0 };
            double[] h2 = { -0.2818107, -1.070786, -1.263184, 0, 0, 0 };
            double[] h3 = { 0.1778064, 0.460504, 0.2340379, -0.4924179, 0, 0 };
            double[] h4 = { -0.0417661, 0, 0, 0.1600435, 0, 0 };
            double[] h5 = { 0, -0.01578386, 0, 0, 0, 0 };
            double[] h6 = { 0, 0, 0, -0.003629481, 0, 0 };

            double T = wsp_TPH(p, h);
            // Check valid area
            if (T > 900 + 273.15
			||(T > 600 + 273.15 && p > 300)
			||(T > 150 + 273.15 && p > 350)
			|| p > 500)	return 0;
            // Calculate density.
            double rho = _DPH(p, h);
            if (rho == 0) return 0;

            double rhos = rho / 317.763;
            double ts = T / 647.226;
            double ps = p / 22.115;
            double sm = 0;
            for (int I = 0; I < 6; I++)
            {
                sm += h0[I] * Math.Pow(1 / ts - 1, I)
                + h1[I] * Math.Pow(1 / ts - 1, I) * Math.Pow(rhos - 1, 1)
                + h2[I] * Math.Pow(1 / ts - 1, I) * Math.Pow(rhos - 1, 2)
                + h3[I] * Math.Pow(1 / ts - 1, I) * Math.Pow(rhos - 1, 3)
                + h4[I] * Math.Pow(1 / ts - 1, I) * Math.Pow(rhos - 1, 4)
                + h5[I] * Math.Pow(1 / ts - 1, I) * Math.Pow(rhos - 1, 5)
                + h6[I] * Math.Pow(1 / ts - 1, I) * Math.Pow(rhos - 1, 6);
            }
            double my0 = Math.Sqrt(ts)  / (1 + 0.978197 / ts + 0.579829 / Math.Pow(ts, 2) - 0.202354 / Math.Pow(ts, 3));
            double my1 = Math.Exp(rhos * sm);
            double mys = my0 * my1;
            return mys * 0.000055071;

        }

        #endregion
        /***********************************************************************************************************/
        #region *5.2 Thermal Conductivity (IAPWS formulation 1985)
        private static double _THERMCONDPTD(double p, double T, double rho)
        {
            // Revised release on the IAPS Formulation 1985 for the Thermal Conductivity of ordinary water
            // IAPWS September 1998
            // Page 8
            if (T < 0 || p < 0.000611657 || T > 800 || p > 400
                || (!(p <= 100 && T <= 100 + 273.15)
                || (p <= 150 && T <= 400 + 273.15)
                || (p <= 200 && T <= 250 + 273.15)
                || (p <= 400 && T <= 125 + 273.15))) return 0;
            T = T / 647.26;
            rho = rho / 317.7;
            double tc0 = Math.Sqrt(T) * (0.0102811 + 0.0299621 * T + 0.0156146 * Math.Pow(T, 2) - 0.00422464 * Math.Pow(T, 3));
            double tc1 = -0.39707 + 0.400302 * rho + 1.06 * Math.Exp(-0.171587 * Math.Pow(rho + 2.39219, 2));
            double dt = Math.Abs(T - 1) + 0.00308976;
            double q = 2 + 0.0822994 / Math.Pow(dt, 3 / 5);
            double s = (T >= 1) ? 1.0 / dt: 10.0932 / Math.Pow(dt, 3 / 5);
            double tc2 = (0.0701309 / Math.Pow(T, 10) + 0.011852) 
                * Math.Pow(rho, 9 / 5) * Math.Exp(0.642857 * (1 - Math.Pow(rho, 14.0 / 5.0))) 
                + 0.00169937 * s * Math.Pow(rho, q) * Math.Exp((q / (1 + q)) * (1 - Math.Pow(rho, 1 + q)))
                - 1.02 * Math.Exp(-4.11717 * Math.Pow(T, 3 / 2) - 6.17937 / Math.Pow(rho, 5));
            return tc0 + tc1 + tc2;
        }
        #endregion
        /***********************************************************************************************************/
        # region 5.3 Surface Tension
        private static double _SURFTENT(double T)
        {
            // IAPWS Release on Surface Tension of Ordinary Water Substance,
            // September 1994

            double b = 0.2358;    // N/m;

            double BB = -0.625;
            double My = 1.256;
            if (T < 0.01 || T > tc) return 0;
            double tau = 1 - T / tc;
            return b * Math.Pow(tau, My) * (1 + BB * tau);
        }
        #endregion
        
    }
}