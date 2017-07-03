using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingCloudSDK.config;
using QingCloudSDK.service;
using System.IO;
using System.Net;


namespace QingCloudSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = new Config("KLVGRRVCZISPWZWUTTNK", "fWvtysXGLcc3ATXRWwuIVjJ6RRIv3hYtqyF3zgNx");//citrix@citrix.com的key和secret
            config.setProtocol("http");
            config.setHost("api.pekdemo.com");
            config.setPort("80");
            Instance intance = new Instance(config, "pekdemo1");//zone名称
            Instance.RunInstancesInput input = new Instance.RunInstancesInput();
            input.setImageId("centos7x64d");
            input.setCpu(2);
            input.setMemory(2048);
            input.setLoginMode("passwd");
            input.setLoginPassword("Zhu88jie");
            input.setCount(1);
            Instance.RunInstancesOutput output = new Instance.RunInstancesOutput();
            output = intance.RunInstances(input);

            // Print the return code.
            Console.WriteLine(output.getRetCode());

            // Print the job ID.
            Console.WriteLine(output.getJobId());
            Console.ReadLine();
        }
        /*
         //StartInstances Demo
        static void Main(string[] args)
        {
            Config config = new Config("KLVGRRVCZISPWZWUTTNK", "fWvtysXGLcc3ATXRWwuIVjJ6RRIv3hYtqyF3zgNx");//citrix@citrix.com的key和secret
            config.setProtocol("http");
            config.setHost("api.pekdemo.com");
            config.setPort("80");
            Instance intance = new Instance(config, "pekdemo1");//zone名称
            Instance.StartInstancesInput input = new Instance.StartInstancesInput();
            input.setInstances(new String[] { "i-tj3e7xpl", "i-71x8sg3x" });
            Instance.StartInstancesOutput output = new Instance.StartInstancesOutput();
            output = intance.StartInstances(input);

            // Print the return code.
            Console.WriteLine(output.getRetCode());

            // Print the job ID.
            Console.WriteLine(output.getJobId());
            Console.ReadLine();
        }
         * */


        /*
         //StopInstances Demo
        static void Main(string[] args)
        {
            Config config = new Config("KLVGRRVCZISPWZWUTTNK", "fWvtysXGLcc3ATXRWwuIVjJ6RRIv3hYtqyF3zgNx");//citrix@citrix.com的key和secret
            config.setProtocol("http");
            config.setHost("api.pekdemo.com");
            config.setPort("80");
            Instance intance = new Instance(config, "pekdemo1");//zone名称
            Instance.StopInstancesInput input = new Instance.StopInstancesInput();
            input.setInstances(new String[] { "i-tj3e7xpl", "i-71x8sg3x" });
            Instance.StopInstancesOutput output = new Instance.StopInstancesOutput();
            output = intance.StopInstances(input);

            // Print the return code.
            Console.WriteLine(output.getRetCode());

            // Print the job ID.
            Console.WriteLine(output.getJobId());
            Console.ReadLine();
        }
         * */
    }
}
