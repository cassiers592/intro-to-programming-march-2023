namespace LearningResourcesApi.Models;

/*
 * {
 *     "status": "Normal",
 *     "lastOutage": 268 days ago,
 *     "upcomingOutages": [],
 *     "forHelp": {
 *          "name": "Bob Smith",
 *          "contactInfo": {
 *              "phone": "888-1212",
 *              "email": "bob@aol.com"
 *          }
 *     }
 * }
 */

// Status is always "Normal", "Degraded", or "OnFire"
public enum StatusLevel { Normal, Degraded, OnFire }
public record StatusResponse(StatusLevel Status, DateTime LastOutage, List<DateTime> UpcomingOutages, StatusHelpInfo ForHelp);

public record StatusHelpInfo (string Contact, Dictionary<string,string> ContactInfo);