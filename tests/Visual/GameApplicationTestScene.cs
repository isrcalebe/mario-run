namespace mario.Game.Tests.Visual;

public partial class GameApplicationTestScene : TestScene
{
    protected override ITestSceneTestRunner CreateRunner()
        => new GameApplicationTestSceneTestRunner();

    private partial class GameApplicationTestSceneTestRunner : GameApplicationBase, ITestSceneTestRunner
    {
        private TestSceneTestRunner.TestRunner? runner;

        protected override void LoadAsyncComplete()
        {
            base.LoadAsyncComplete();

            Add(runner = new TestSceneTestRunner.TestRunner());
        }

        public void RunTestBlocking(TestScene test)
            => runner?.RunTestBlocking(test);
    }
}
