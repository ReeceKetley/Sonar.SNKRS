using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;

namespace SonarSNKRS
{
    class SMSProviders
    {
        public static Dictionary<string, string> Providers = new Dictionary<string, string>();

        private static void Add(string id, string key)
        {
            if (!Providers.ContainsKey(id))
            {
                Providers.Add(id, key);
            }
        }

        public static void AddProviders()
        {
            try
            {
                Add("AT&T", "@txt.att.net");
                Add("Boost Mobile", "@myboostmobile.com");
                Add("Nextel", "@messaging.nextel.com");
                Add("Sprint", "@messaging.sprintpcs.com");
                Add("T-Mobile", "@tmomail.net");
                Add("US Cellular", "@email.uscc.net");
                Add("Verizon", "@vtext.com");
                Add("Virgin Mobile", "@vmobl.com");
                Add("3 River Wireless", "@sms.3rivers.net");
                Add("ACS Wireless", "@paging.acswireless.com");
                Add("Alltel", "@message.alltel.com");
                Add("Bell Mobility", "@txt.bellmobility.ca");
                Add("Blue Sky Frog", "@blueskyfrog.com");
                Add("Bluegrass Cellular", "@sms.bluecell.com");
                Add("BPL Mobile", "@bplmobile.com");
                Add("Carolina West Wireless", "@cwwsms.com");
                Add("Cellular One", "@mobile.celloneusa.com");
                Add("Cellular South", "@csouth1.com");
                Add("Centennial Wireless", "@cwemail.com");
                Add("CenturyTel", "@messaging.centurytel.net");
                Add("Clearnet", "@msg.clearnet.com");
                Add("Comcast", "@comcastpcs.textmsg.com");
                Add("Corr Wireless Communications", "@corrwireless.net");
                Add("Dobson", "@mobile.dobson.net");
                Add("Edge Wireless", "@sms.edgewireless.com");
                Add("Fido", "@fido.ca");
                Add("Golden Telecom", "@sms.goldentele.com");
                Add("Helio", "@messaging.sprintpcs.com");
                Add("Houston Cellular", "@text.houstoncellular.net");
                Add("Idea Cellular", "@ideacellular.net");
                Add("Illinois Valley Cellular", "@ivctext.com");
                Add("Inland Cellular Telephone", "@inlandlink.com");
                Add("MCI", "@pagemci.com");
                Add("Metrocall", "@page.metrocall.com");
                Add("Metrocall 2-way", "10digitpagernumber@my2way.com");
                Add("Metro PCS", "@mymetropcs.com");
                Add("Microcell", "@fido.ca");
                Add("Midwest Wireless", "@clearlydigital.com");
                Add("Mobilcomm", "@mobilecomm.net");
                Add("MTS", "@text.mtsmobility.com");
                Add("OnlineBeep", "@onlinebeep.net");
                Add("PCS One", "@pcsone.net");
                Add("President's Choice", "@txt.bell.ca");
                Add("Public Service Cellular", "@sms.pscel.com");
                Add("Qwest", "@qwestmp.com");
                Add("Rogers AT&T Wireless", "@pcs.rogers.com");
                Add("Rogers Canada", "@pcs.rogers.com");
                Add("Satellink", "@satellink.net");
                Add("Southwestern Bell", "@email.swbw.com");
                Add("Sumcom", "@tms.suncom.com");
                Add("Surewest Communicaitons", "@mobile.surewest.com");
                Add("Telus", "@msg.telus.com");
                Add("Tracfone", "@txt.att.net");
                Add("Triton", "@tms.suncom.com");
                Add("Unicel", "@utext.com");
                Add("Solo Mobile", "@txt.bell.ca");
                Add("Sprint", "@messaging.sprintpcs.com");
                Add("Sumcom", "@tms.suncom.com");
                Add("Surewest Communicaitons", "@mobile.surewest.com");
                Add("Telus", "@msg.telus.com");
                Add("Triton", "@tms.suncom.com");
                Add("Unicel", "@utext.com");
                Add("US Cellular", "@email.uscc.net");
                Add("US West", "@uswestdatamail.com");
                Add("Virgin Mobile Canada", "@vmobile.ca");
                Add("West Central Wireless", "@sms.wcc.net");
                Add("Western Wireless", "@cellularonewest.com");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
