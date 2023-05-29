import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

class Product {
    private String name;
    private int stock;

    public Product(String name, int stock) {
        this.name = name;
        this.stock = stock;
    }

    public String getName() {
        return name;
    }

    public int getStock() {
        return stock;
    }

    public void setStock(int stock) {
        this.stock = stock;
    }
}

class InventoryManager {
    private Map<String, Product> inventory;

    public InventoryManager() {
        inventory = new HashMap<>();
    }

    public void addProduct(String name, int stock) {
        if (inventory.containsKey(name)) {
            System.out.println("Product already exists in the inventory.");
        } else {
            Product product = new Product(name, stock);
            inventory.put(name, product);
            System.out.println("Product added to the inventory.");
        }
    }

    public void updateProduct(String name, int stock) {
        Product product = inventory.get(name);
        if (product != null) {
            product.setStock(stock);
            System.out.println("Product stock updated.");
        } else {
            System.out.println("Product does not exist in the inventory.");
        }
    }

    public void removeProduct(String name) {
        if (inventory.containsKey(name)) {
            inventory.remove(name);
            System.out.println("Product removed from the inventory.");
        } else {
            System.out.println("Product does not exist in the inventory.");
        }
    }

    public void checkStock(String name) {
        Product product = inventory.get(name);
        if (product != null) {
            System.out.println("Available stock for " + name + ": " + product.getStock());
        } else {
            System.out.println("Product does not exist in the inventory.");
        }
    }
}

public class Main {
    public static void main(String[] args) {
        InventoryManager inventoryManager = new InventoryManager();
        Scanner scanner = new Scanner(System.in);
        int choice = 0;

        while (choice != 5) {
            System.out.println("\n===== E-commerce Inventory Management System =====");
            System.out.println("1. Add Product");
            System.out.println("2. Update Product Stock");
            System.out.println("3. Remove Product");
            System.out.println("4. Check Available Stock");
            System.out.println("5. Exit");
            System.out.print("Enter your choice: ");
            choice = scanner.nextInt();

            switch (choice) {
                case 1:
                    System.out.print("Enter product name: ");
                    scanner.nextLine(); // Consume the newline character
                    String productName = scanner.nextLine();
                    System.out.print("Enter product stock: ");
                    int productStock = scanner.nextInt();
                    inventoryManager.addProduct(productName, productStock);
                    break;
                case 2:
                    System.out.print("Enter product name: ");
                    scanner.nextLine(); // Consume the newline character
                    productName = scanner.nextLine();
                    System.out.print("Enter updated stock: ");
                    productStock = scanner.nextInt();
                    inventoryManager.updateProduct(productName, productStock);
                    break;
                case 3:
                    System.out.print("Enter product name: ");
                    scanner.nextLine(); // Consume the newline character
                    productName = scanner.nextLine();
                    inventoryManager.removeProduct(productName);
                    break;
                case 4:
                    System.out.print("Enter product name: ");
                    scanner.nextLine(); // Consume the newline character
                    productName = scanner.nextLine();
                    inventoryManager.checkStock(productName);
                    break;
                case 5:
                    System.out.println("Exiting...");
                    break;
                default:
                    System.out.println("Invalid choice. Please try again.");
            }
        }
        scanner.close();
    }
}
