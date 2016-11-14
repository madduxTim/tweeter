using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweeter.Models;

namespace Tweeter.DAL
{
    public class TweeterRepo
    {
        public TweeterContext Context { get; set; }
        public TweeterRepo() { }
        public TweeterRepo(TweeterContext _context)
        {
            Context = _context;
        }
    }
}