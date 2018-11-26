using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsWebService
{
    public struct Query
    {
        public Query(string text, List<LiteSQLParameter> parameters = null)
        {
            this.Text = text;
            this.Parameters = parameters;
        }

        public string Text { get; }
        public List<LiteSQLParameter> Parameters { get; }
    }
}