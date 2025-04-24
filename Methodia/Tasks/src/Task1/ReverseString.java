package Task1;

public class ReverseString {
    public static void main(String[] args) {
        String originalString = "This is a test string";
        char[] chars = originalString.toCharArray();

        int leftSide = 0;
        int rightSide = chars.length - 1;

        while (leftSide < rightSide) {
            // Размяна
            char temp = chars[leftSide];
            chars[leftSide] = chars[rightSide];
            chars[rightSide] = temp;

            leftSide++;
            rightSide--;
        }

        String reversedString = new String(chars);
        System.out.println("Original string: " + originalString);
        System.out.println("Reversed string: " + reversedString);
    }
}