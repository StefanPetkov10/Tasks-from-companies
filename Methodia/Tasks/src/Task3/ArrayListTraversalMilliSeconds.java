package Task3;

import java.util.*;

public class ArrayListTraversalMilliSeconds {
    public static void main(String[] args) {
        List<String> list = new ArrayList<>();
        for (int i = 0; i < 1000000; i++) {
            list.add("Element " + i);
        }

        long startTime = System.nanoTime();
        for (int i = 0; i < list.size(); i++) {
            String element = list.get(i);
        }
        long endTime = System.nanoTime();
        System.out.println("Time for for loop: " + (endTime - startTime) / 1000000 + " ms");

        startTime = System.nanoTime();
        int index = 0;
        while (index < list.size()) {
            String element = list.get(index);
            index++;
        }
        endTime = System.nanoTime();
        System.out.println("Time for while loop: " + (endTime - startTime) / 1000000 + " ms");

        startTime = System.nanoTime();
        Iterator<String> iterator = list.iterator();
        while (iterator.hasNext()) {
            String element = iterator.next();
        }
        endTime = System.nanoTime();
        System.out.println("Time for Iterator: " + (endTime - startTime) / 1000000 + " ms");
    }
}
