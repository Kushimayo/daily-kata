package com.example.diamondprint

import org.junit.Assert
import org.junit.Assert.*
import org.junit.Test

class SolutaionTest {
    @Test
    fun test_start() {
        assertEquals(1, 1)
    }

    @Test
    fun A_Diamond_return_A() {
        val sol = Solutaion()
        val expect = "A"
        Assert.assertEquals(expect, sol.DiamondPrint('A'))
    }

    @Test
    fun B_return_B_Diamond() {
        val sol = Solutaion()
        val expect = " A\n" +
                      "B B\n" +
                      " A\n"
        Assert.assertEquals(expect, sol.DiamondPrint('B'))
    }

    @Test
    fun C_return_C_Diamond() {
        val sol = Solutaion()
        val expect = "  A\n" +
                     " B B\n" +
                     "C   C\n" +
                     " B B\n" +
                     "  A\n"
        Assert.assertEquals(expect, sol.DiamondPrint('C'))
    }
}