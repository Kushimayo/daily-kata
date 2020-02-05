public class Sample2 {

    public String DiamondPrint(char mid) {
        String top = "";
        String bottom = "";
        if (mid == 'A')
            return top += mid;

        for (char c = 'A'; c <=mid; c++) {
            String line = addIndent(mid, c) + c + addRestOfLine(c) + '\n';
            top += line;

            if(c != mid) {
                bottom = line + bottom;
            }
        }

        return top + bottom;
    }

    private String addRestOfLine(char c) {
        if (c != 'A') {
            int count = (c - 'A') * 2 -1;
            return addSpaces(count) + c;
        } else
            return "";

    }

    private String addIndent(char mid, char c) {
        return addSpaces(mid - c);
    }

    private String addSpaces(int count) {
        String spaces = "";
        for (int i = 0; i < count; i++)
            spaces += " ";
        return spaces;
    }
}
