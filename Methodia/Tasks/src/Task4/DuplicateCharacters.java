package Task4;

import java.util.*;

public class DuplicateCharacters {
    public static void main(String[] args) {
        String input = "Methodia FullStack Academy";

        input = input.toLowerCase().replaceAll("[.,!? ]", "");

        Map<Character, Integer> charCount = new HashMap<>();

        for (char c : input.toCharArray()) {
            charCount.put(c, charCount.getOrDefault(c, 0) + 1);
        }

        System.out.println("Duplicate characters:");
        for (Map.Entry<Character, Integer> entry : charCount.entrySet()) {
            if (entry.getValue() > 1) {
                System.out.println(entry.getKey() + " → " + entry.getValue() + " times");
            }
        }
    }
}

