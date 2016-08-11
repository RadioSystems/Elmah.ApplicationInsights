# Elmah.ApplicationInsights
Elmah log extender for Application Insights.

This project extends the XML file error logger for ELMAH by subclassing the XML File error logger to first log to Microsoft Application Insights, before writing to the XML file. This will allow for the elmah.axd to still be avialable and will allow logging to continue if Azure access is unavailable.
