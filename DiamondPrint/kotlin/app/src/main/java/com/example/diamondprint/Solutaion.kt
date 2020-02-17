package com.example.diamondprint

class Solutaion {
    fun DiamondPrint(mid: Char): String {
        if (mid == 'A')
            return mid.toString()

        var top = ""
        var bottom = ""

        for (current in 'A'..mid) {
            var line = buildLine(current, mid)
            top = buildTop(top, line)
            bottom = buildBottom(bottom, line, current, mid)
        }
        return top + bottom
    }

    private fun buildTop(pre:String, add:String) :String {
        return pre + add
    }

    private fun buildBottom(pre:String,add:String, c:Char, mid:Char): String {
        if (c != mid)
            return add + pre
        return pre
    }

    private fun buildLine(c: Char, mid: Char): String {
        var result = ""

        // add intent
        for (intent in c..mid -1) {
            result += " "
        }

        // add char
        result += c.toString()
        if (c != 'A') {
            var count = (c - 'A') *2 -1
            for (intent in 1..count) {
                result += " "
            }
            result += c.toString()
        }

        result += "\n"
        return result
    }

    private fun addIntent(c: Char, mid: Char): String {
        var result = ""
        for (intent in c..mid -1) {
            result += " "
        }
        return result
    }
}