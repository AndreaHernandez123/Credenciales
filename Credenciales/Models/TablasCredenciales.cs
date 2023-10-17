using Credenciales.Models.Credenciales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Credenciales.Models
{
    public class TablasCredenciales
    {
        CredencialesEntities cred = new CredencialesEntities();
        public List<SelectListItem> llenaAreas()
        {
            List<SelectListItem> ob = new List<SelectListItem>();
            List<ListAreasViewModel> lst = null;
            lst = (from d in cred.Nombre_Areas
                   select new ListAreasViewModel
                   {
                       id = d.Id,
                       Area = d.Area
                   }).ToList();
            foreach (var item in lst)
            {
                ob.Add(new SelectListItem
                {
                    Text = item.Area
                });
            }
            return ob;

        }
    }
}