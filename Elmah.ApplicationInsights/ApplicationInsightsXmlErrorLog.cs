using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.ApplicationInsights;

namespace Elmah.ApplicationInsights {
    public class ApplicationInsightsXmlErrorLog : XmlFileErrorLog {
        private readonly TelemetryClient _telemtryClient;

        public ApplicationInsightsXmlErrorLog(IDictionary config) : base(config) {
            _telemtryClient = new TelemetryClient();
        }

        public ApplicationInsightsXmlErrorLog(string logPath) : base(logPath) {
            _telemtryClient = new TelemetryClient();
        }

        public override string Log(Error error) {
            var properties = new Dictionary<string, string> {
                {
                    nameof(error.ApplicationName), error.ApplicationName
                }, {
                    nameof(error.Detail), error.Detail
                }, {
                    nameof(error.Cookies), error.Cookies.ToString()
                }, {
                    nameof(error.Form), error.Form.ToString()
                }, {
                    nameof(error.HostName), error.HostName
                }, {
                    nameof(error.Source), error.Source
                }, {
                    nameof(error.Time), error.Time.ToString(CultureInfo.InvariantCulture)
                }, {
                    nameof(error.User), error.User
                }, {
                    nameof(error.Message), error.Message
                }, {
                    nameof(error.StatusCode), error.StatusCode.ToString()
                }, {
                    nameof(error.ServerVariables), error.ServerVariables.ToString()
                }
            };
            _telemtryClient.TrackException(error.Exception, properties);
            return base.Log(error);
        }
    }
}
