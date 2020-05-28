using System;
using System.Collections.Generic;
using System.Text;

namespace Push.Common.Constants
{
    public class PushConstants
    {
        public const string ByPassMessage = "The request queue has been processed by bypassing";
        public const string ProcessingQueueMessage = "it's being processing the request queue:{0}";
        public const string RequestQueueToProcessMessage = "The amount of request queue for {0} to process are: {1} ";
        public const string NoRequestQueueToProcessMessage = "No items found in {0} queue";
        public const string StartedPushMessage = "The {0} push process has started ";
        public const string EndedPushMessage = "The {0} push process has ended ";
        public const string StatusCodeMessage = "The http status code result was {0}: ";
        public const string StatusCodeMessageDetailed = "The http status code result was {0} for queue {1}";
        public const string CallingEndpointMessage = "Calling endpoint: {0}";
        public const string MissingTokenMessage = "it wasn't able to retrieve the token";
        public const string EmptyPayloadMessage = "Error found while processing queue item {0}. The paylod is empty";
        public const string ProcessedQueueMessage = "Queue item {0} has been processed";
    }
}
