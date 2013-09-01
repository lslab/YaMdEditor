﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YaMdEditor
{
	public class HtmlHeader
	{
		private string _Strict;
		private string _Transitional;
		private string _Frameset;
		private string _HTML5;

		public string Strict
		{
			get { return _Strict; }
		}
		public string Transitional
		{
			get { return _Transitional; }
		}
		public string Frameset
		{
			get { return _Frameset; }
		}
		public string HTML5
		{
			get { return _HTML5; }
		}

		public HtmlHeader()
		{
			_Strict = "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.01//EN' 'http://www.w3.org/TR/html4/strict.dtd'>";
			_Transitional = "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.01 Transitional//EN' 'http://www.w3.org/TR/html4/loose.dtd'>";
			_Frameset = "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.01 Frameset//EN' 'http://www.w3.org/TR/html4/frameset.dtd'>";
			_HTML5 = "<!DOCTYPE html>";
		}

		public string GetHtmlHeader(string name)
		{
			if (name == "Strict DTD")
			{
				return (_Strict);
			}
			else if (name == "Transitional DTD")
			{
				return (_Transitional);
			}
			else if (name == "Frameset DTD")
			{
				return (_Frameset);
			}
			else if (name == "HTML5")
			{
				return (_HTML5);
			}
			else
			{
				return (_Strict);
			}
		}
		
        public string[] GetHeaderTypeList()
		{
			return (new string[] { "Strict DTD", "Transitional DTD", "Frameset DTD", "HTML5" });
		}
		
	}
}
