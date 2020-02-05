import org.junit.Assert;
import org.junit.Test;

import static org.junit.Assert.*;

public class Sample2Test {
    @Test
    public void A_insert_return_A() {
        Sample2 sample = new Sample2();
        String result = sample.DiamondPrint('A');
        Assert.assertEquals("A", result);
    }
    @Test
    public void B_insert_return_B_Diamond() {
        Sample2 sample = new Sample2();
        String result = sample.DiamondPrint('B');
        String expect = " A\n" +
                        "B B\n" +
                        " A\n";
        Assert.assertEquals(expect, result);

    }

    @Test
    public void C_insert_return_C_Diamond() {
        Sample2 sample = new Sample2();
        String result = sample.DiamondPrint('C');
        String expect = "  A\n" +
                        " B B\n" +
                        "C   C\n" +
                        " B B\n" +
                        "  A\n";
        Assert.assertEquals(expect, result);

    }


}