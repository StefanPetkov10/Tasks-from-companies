package Task2;

import java.util.*;

public class SortedDictionary {
    public static void main(String[] args) {
        String text = "This is a test. This TEST is only a Test! Is this a test? Yes, this is a TesT.";

        text = text.toLowerCase().replaceAll("[.,!?]", "");

        String[] words = text.split("\\s+");

        Map<String, Integer> wordCounts = new HashMap<>();
        for (String word : words) {
            wordCounts.put(word, wordCounts.getOrDefault(word, 0) + 1);
        }

        List<Map.Entry<String, Integer>> sortedList = new ArrayList<>(wordCounts.entrySet());

        sortedList.sort((a, b) -> {
            int compare = b.getValue().compareTo(a.getValue());
            if (compare != 0)
            {
                return compare;
            }

            return a.getKey().compareTo(b.getKey());
        });

        Map<String, Integer> sortedMap = new HashMap<>();
        for (Map.Entry<String, Integer> entry : sortedList) {
            sortedMap.put(entry.getKey(), entry.getValue());
        }

        System.out.println("Sorted Dictionary:");
        for (Map.Entry<String, Integer> entry : sortedMap.entrySet()) {
            System.out.println(entry.getKey() + ": " + entry.getValue());
        }
    }
}
