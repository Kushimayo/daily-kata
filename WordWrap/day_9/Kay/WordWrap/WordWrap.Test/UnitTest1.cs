using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrap.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WordWrapper�ν��Ͻ���_�����Ҽ��ִ�()
        {
            var wordWrapper = new WordWrapper();
        }

        [TestMethod]
        public void col_ũ�Ⱑ����ϸ�_�־�����Ʈ���̱״�ι�ȯ�ȴ�()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("test", wordWrapper.doWrap("test", 7));
        }

        [TestMethod]
        public void col_ũ�⺸������_�ΰ��Ǵܾ��ϰ��_�����̽�����������Wrap�ȴ�()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("hello--world", wordWrapper.doWrap("hello world", 7));
        }

        [TestMethod]
        public void col_ũ�⺸������_�������Ǵܾ��ϰ��_�����̽�����������Wrap�ȴ�()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("a lot of--words for--a single--line", wordWrapper.doWrap("a lot of words for a single line", 10));
        }

        [TestMethod]
        public void col_ũ���_������_ũ���ǴܾWrap�̵Ǹ罺���̽������ŵȴ�()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("this--is a--test", wordWrapper.doWrap("this is a test", 4));
        }

        [TestMethod]
        public void �����̽�����_���Ǵܾ_col_ũ�⺸��ũ�ٸ�_�ܾ��߰�����Wrap�ȴ�()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("a long--word", wordWrapper.doWrap("a longword", 6));
        }

        [TestMethod]
        public void �Ѵܾ_col_ũ�⺸��ũ�ٸ�_�ܾWrap�ȴ�()
        {
            var wordWrapper = new WordWrapper();
            Assert.AreEqual("areall--ylongw--ord", wordWrapper.doWrap("areallylongword", 6));
        }
    }
}
