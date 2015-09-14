using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stormancer;
using Stormancer.Core;
using Stormancer.Diagnostics;
using Stormancer.Server.Components;
using Stormancer.Plugins;

namespace ConsoleApplication1
{
    public class app
    {
        public void Run(IAppBuilder builder)
        {
            builder.AddGameScene();

        }
    }

    static class GameSceneExtensions
    {
        public static void AddGameScene(this IAppBuilder builder)
        {
            builder.SceneTemplate("test", scene => new Test(scene));
        }
    }

    class Test
    {
        private ISceneHost _scene;

        public Test(ISceneHost scene)
        {
            _scene = scene;
            _scene.GetComponent<ILogger>().Debug("server", "starting configuration");

            _scene.AddProcedure("test_rpc", onTest);
           _scene.GetComponent<ILogger>().Debug("server", "configuration complete");
        }

        private Task onTest(RequestContext<IScenePeerClient> ctx)
        {
            ctx.SendValue("");
            return Task.FromResult(true);
        }

    }
}
