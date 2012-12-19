﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using wojilu.Aop;
using System.Reflection;

namespace wojilu.Test.Aop {



    [TestFixture]
    public class AopTest {





        [Test]
        public void testSubClassProxy() {

            // 代理类是子类
            MyAopService s1 = AopContext.CreateProxy<MyAopService>();
            Boolean isSubClass = s1.GetType().IsSubclassOf( typeof( MyAopService ) );
            Assert.IsTrue( isSubClass );
            Assert.AreEqual( "__" + typeof( MyAopService ).Name, s1.GetType().Name );


            Assert.AreNotEqual( typeof( MyAopService ), s1.GetType() );

            s1.Save();
            Console.WriteLine();
            Console.WriteLine();

            // 未修改结果
            int result1 = s1.Update( 88 );
            Assert.AreEqual( MyAopService.UpdateResult, result1 );
            Console.WriteLine();
            Console.WriteLine();

            s1.GetBy( "myname", 3 );
            Console.WriteLine();
            Console.WriteLine();

            // 边界测试：null
            List<String> result2 = s1.GetCat();
            Assert.IsNull( result2 );
            Console.WriteLine();
            Console.WriteLine();

            // 泛型列表
            List<String> result3 = s1.GetDog();
            Assert.IsNotNull( result3 );
            Assert.AreEqual( 0, result3.Count );
            Console.WriteLine();
            Console.WriteLine();

            // 后置修改：修改结果数据
            List<MyCat> result4 = s1.GetCat2();
            Assert.IsNotNull( result4 );
            Assert.AreEqual( 4, result4.Count );
            Assert.AreEqual( "cat999", result4[3].Name );
            Console.WriteLine();
            Console.WriteLine();

            // 未监控的方法
            s1.NormalMethod();
            Console.WriteLine();
            Console.WriteLine();

            // 未监控的虚方法
            s1.NormalVirtualMethod();
            Console.WriteLine();
            Console.WriteLine();

            // 没有监控的对象，则没有代理类
            MyNormalService s2 = AopContext.CreateProxy<MyNormalService>();
            Assert.IsNull( s2 );

            // 不管有没有监控，CreateObject 都返回结果
            MyNormalService s3 = AopContext.CreateObject<MyNormalService>();
            Assert.IsNotNull( s3 );
            Assert.AreEqual( typeof( MyNormalService ), s3.GetType() );

            // 测试参数是否成功修改
            MyArgService x1 = AopContext.CreateProxy<MyArgService>();

            Console.WriteLine( "buy1" );
            int xResult1 = x1.Buy( 3 );
            Console.WriteLine();

            Console.WriteLine( "buy2" );
            int xResult2 = x1.Buy( 5 );

            Assert.AreEqual( 8, xResult1 );
            Assert.AreEqual( 12, xResult2 );

        }



        [Test]
        public void testInterfaceClassProxy() {

            // 代理类是接口
            IMyAopService s1 = AopContext.CreateProxy<IMyAopService>( typeof( MyAopService ) );

            Assert.AreNotEqual( typeof( MyAopService ), s1.GetType() );

            s1.Save();
            Console.WriteLine();
            Console.WriteLine();

            // 未修改结果
            int result1 = s1.Update( 88 );
            Assert.AreEqual( MyAopService.UpdateResult, result1 );
            Console.WriteLine();
            Console.WriteLine();

            s1.GetBy( "myname", 3 );
            Console.WriteLine();
            Console.WriteLine();

            // 边界测试：null
            List<String> result2 = s1.GetCat();
            Assert.IsNull( result2 );
            Console.WriteLine();
            Console.WriteLine();

            // 泛型列表
            List<String> result3 = s1.GetDog();
            Assert.IsNotNull( result3 );
            Assert.AreEqual( 0, result3.Count );
            Console.WriteLine();
            Console.WriteLine();

            // 后置修改：修改结果数据
            List<MyCat> result4 = s1.GetCat2();
            Assert.IsNotNull( result4 );
            Assert.AreEqual( 4, result4.Count );
            Assert.AreEqual( "cat999", result4[3].Name );
            Console.WriteLine();
            Console.WriteLine();

            // 未监控的方法
            s1.NormalMethod();
            Console.WriteLine();
            Console.WriteLine();

            // 未监控的虚方法
            s1.NormalVirtualMethod();
            Console.WriteLine();
            Console.WriteLine();

            // 没有监控的对象，则没有代理类
            MyNormalService s2 = AopContext.CreateProxy<MyNormalService>();
            Assert.IsNull( s2 );

            // 不管有没有监控，CreateObject 都返回结果
            MyNormalService s3 = AopContext.CreateObject<MyNormalService>();
            Assert.IsNotNull( s3 );
            Assert.AreEqual( typeof( MyNormalService ), s3.GetType() );

            // 测试参数是否成功修改
            MyArgService x1 = AopContext.CreateProxy<MyArgService>();

            Console.WriteLine( "buy1" );
            int xResult1 = x1.Buy( 3 );
            Console.WriteLine();

            Console.WriteLine( "buy2" );
            int xResult2 = x1.Buy( 5 );

            Assert.AreEqual( 8, xResult1 );
            Assert.AreEqual( 12, xResult2 );

        }

    }
}
