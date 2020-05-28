using Amazon;
using Amazon.S3;
using System;

namespace AccessAwsS3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var awsAccessKeyId = "";
            var awsAccessKeySecret = "";
            var bucketName = "filesfromftp";

            var awsClient = new AmazonS3Client(awsAccessKeyId, awsAccessKeySecret, RegionEndpoint.USEast2);
        }
    }
}
