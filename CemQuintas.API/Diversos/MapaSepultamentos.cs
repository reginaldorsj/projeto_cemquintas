using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Regisoft.Data.DbClient;
using CemQuintas.API.Models;

namespace CemQuintas
{
    public class MapaSepultamentos
    {
        public IList<TotalAnual> GetTotais()
        {
            List<TotalAnual> lst = new List<TotalAnual>();
            DataTable dtDados = getDados();
            if (dtDados==null || dtDados.Rows.Count == 0)
                return null;

            DataRow dr;
            string ano = dtDados.Rows[0]["ano"].ToString(), mes;
            int[] tot = new int[12];
            for (int m = 0; m < 12; m++)
                tot[m] = 0;
            for (int n = 0; n < dtDados.Rows.Count; n++)
            {
                dr = dtDados.Rows[n];

                if (dr["ano"].ToString() == string.Empty)
                    continue;

                mes = dtDados.Rows[n]["mes"].ToString();
                if (dr["ano"].ToString() != ano)
                {
                    if (ano != string.Empty)
                    {
                        TotalAnual totAno = new TotalAnual();
                        totAno.Ano = Convert.ToInt32(ano);
                        totAno.Jan = tot[0];
                        totAno.Fev = tot[1];
                        totAno.Mar = tot[2];
                        totAno.Abr = tot[3];
                        totAno.Mai = tot[4];
                        totAno.Jun = tot[5];
                        totAno.Jul = tot[6];
                        totAno.Ago = tot[7];
                        totAno.Set = tot[8];
                        totAno.Out = tot[9];
                        totAno.Nov = tot[10];
                        totAno.Dez = tot[11];
                        totAno.Total = tot[0] + tot[1] + tot[2] + tot[3] + tot[4] + tot[5] + tot[6] + tot[7] + tot[8] + tot[9] + tot[10] + tot[11];
                        lst.Add(totAno);

                        for (int m = 0; m < 12; m++)
                            tot[m] = 0;
                    }
                    ano = dtDados.Rows[n]["ano"].ToString();
                }

                if (dtDados.Rows[n]["mes"].ToString() == "1")
                    tot[0] += Convert.ToInt32(dr["total"]);
                if (dtDados.Rows[n]["mes"].ToString() == "2")
                    tot[1] += Convert.ToInt32(dr["total"]);
                if (dtDados.Rows[n]["mes"].ToString() == "3")
                    tot[2] += Convert.ToInt32(dr["total"]);
                if (dtDados.Rows[n]["mes"].ToString() == "4")
                    tot[3] += Convert.ToInt32(dr["total"]);
                if (dtDados.Rows[n]["mes"].ToString() == "5")
                    tot[4] += Convert.ToInt32(dr["total"]);
                if (dtDados.Rows[n]["mes"].ToString() == "6")
                    tot[5] += Convert.ToInt32(dr["total"]);
                if (dtDados.Rows[n]["mes"].ToString() == "7")
                    tot[6] += Convert.ToInt32(dr["total"]);
                if (dtDados.Rows[n]["mes"].ToString() == "8")
                    tot[7] += Convert.ToInt32(dr["total"]);
                if (dtDados.Rows[n]["mes"].ToString() == "9")
                    tot[8] += Convert.ToInt32(dr["total"]);
                if (dtDados.Rows[n]["mes"].ToString() == "10")
                    tot[9] += Convert.ToInt32(dr["total"]);
                if (dtDados.Rows[n]["mes"].ToString() == "11")
                    tot[10] += Convert.ToInt32(dr["total"]);
                if (dtDados.Rows[n]["mes"].ToString() == "12")
                    tot[11] += Convert.ToInt32(dr["total"]);
            }
            TotalAnual tLast = new TotalAnual();
            tLast.Ano = Convert.ToInt32(ano);
            tLast.Jan = tot[0];
            tLast.Fev = tot[1];
            tLast.Mar = tot[2];
            tLast.Abr = tot[3];
            tLast.Mai = tot[4];
            tLast.Jun = tot[5];
            tLast.Jul = tot[6];
            tLast.Ago = tot[7];
            tLast.Set = tot[8];
            tLast.Out = tot[9];
            tLast.Nov = tot[10];
            tLast.Dez = tot[11];
            tLast.Total = tot[0] + tot[1] + tot[2] + tot[3] + tot[4] + tot[5] + tot[6] + tot[7] + tot[8] + tot[9] + tot[10] + tot[11];
            lst.Add(tLast);

            return lst;
        }

        protected DataTable getDados()
        {
            DbFactory db = new DbFactory(Regisoft.Data.DbClient.DbType.Firebird, Regisoft.Config.Get("csCemQuintas"));
            DataTable dt;
            try
            {
                dt = db.ExecuteQuery(@"select extract(year from data_hora_sepultamento) ""ano"", 
                                                    extract(month from data_hora_sepultamento) ""mes"", 
                                                    count(*) ""total"" 
                                                from sepultamento 
                                                group by extract(year from data_hora_sepultamento), extract(month from data_hora_sepultamento) 
                                                order by extract(year from data_hora_sepultamento), extract(month from data_hora_sepultamento)");
            }
            catch
            {
                return null;
            }
            return dt;
        }
    }
}