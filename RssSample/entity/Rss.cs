using System;
namespace RssSample.entity {
    public class Rss {
        public string title {
            get;
            set;
        }
        public string link {
            get;
            set;
        }
        public string pubDate {
            get;
            set;
        }
        public string guide {
            get;
            set;
        }

        public string enclosureUrl {
            get;
            set;
        }
        public string enclosureType {
            get;
            set;
        }
        public Rss(){
            this.title = "";
        }
    }
}
