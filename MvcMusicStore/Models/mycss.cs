using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    public class mycss:  System.Web.UI.MasterPage
    {
        private string _bodyId;
        public string BodyId
        {
            get { return _bodyId; }
            set { _bodyId = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}