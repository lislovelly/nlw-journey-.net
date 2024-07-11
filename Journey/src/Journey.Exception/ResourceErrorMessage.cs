namespace Journey.Exception
{
    public class ResourceErrorMessage
    {
        public static string NAME_EMPTY => "Name must not be empty";
        public static string DATE_TRIP_MUST_BE_LATER_THAN_TODAY => "Date of the trip must be later than today";
        public static string END_DATE_TRIP_MUST_BE_LATER_START_DATE => "The end date of the trip equal to or later than the start day ";
        public static string TRIP_NOT_FOUND => "Trip not found";
        public static string DATE_NOT_WITHIN_TRAVEL_PERIOD => "The selected activity date is not within the travel period.";
        public static string ACTIVITY_NOT_FOUND => "Activity not found";
    }
}