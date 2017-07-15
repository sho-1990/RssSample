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
        public string enclosure {
            get;
            set;
        }
        public string guide {
            get;
            set;
        }

        public class Enclosure {
            public string url {
                get;
                set;
            }
            public string type {
                get;
                set;
            }
        }
        public Rss(){
            this.title = "";
        }
    }
}
