#include <iostream>
#include <queue>
#include <vector>
#include <string>
#include <unordered_map>
#include <Windows.h>
using namespace std;

struct Node {
    char ch;
    int freq;
    int ord;
    Node* left;
    Node* right;

    Node(char character, int frequency, int order) {
        ch = character;
        freq = frequency;
        ord = order;
        left = right = nullptr;
    }
};

struct Compare {
    bool operator()(Node* l, Node* r) {

        if (l->freq == r->freq) {
            return l->ch < r->ch;
        }

        return l->freq > r->freq;
    }
};

Node* buildHuffmanTree(unordered_map<char, int>& freqMap, unordered_map<char, int>& order) {

    priority_queue<Node*, vector<Node*>, Compare> minHeap;

    for (auto& pair : freqMap) {
        char ch = pair.first;
        int frequency = pair.second;
        int index = order[ch]; 
        minHeap.push(new Node(ch, frequency, index));
    }

    while (minHeap.size() > 1) {

        Node* left = minHeap.top(); minHeap.pop();
        Node* right = minHeap.top(); minHeap.pop();

        Node* newNode = new Node('\0', left->freq + right->freq, max(left->ord, right->ord));
        newNode->left = left;
        newNode->right = right;

        minHeap.push(newNode);
    }

    return minHeap.top();
}

void generateHuffmanCodes(Node* root, string str, unordered_map<char, string>& huffmanCode) {
    if (!root) {
        return;
    }

    if (!root->left && !root->right) {
        huffmanCode[root->ch] = str;
    }

    generateHuffmanCodes(root->left, str + "0", huffmanCode);
    generateHuffmanCodes(root->right, str + "1", huffmanCode);
}

void deleteTree(Node* root) {
    if (root) {
        deleteTree(root->left);
        deleteTree(root->right);
        delete root;
    }
}

int main() {

    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    string text;
    cout << "Введите текст для кодирования: ";
    getline(cin, text);
    cout << "Исходная строка: " << text << endl;

    // Шаг 1
    unordered_map<char, int> freqMap;
    unordered_map<char, int> order;
    int ind = 0;
    for (char ch : text) {

        if (freqMap.find(ch) == freqMap.end()) {
            order[ch] = ind++;
        }

        freqMap[ch]++;
    }

    cout << "Таблица встречаемости символов:\n";
    for (const auto& pair : freqMap) {
        cout << "'" << pair.first << "' встречается " << pair.second << " раз/а\n";
    }

    // Шаг 2
    Node* root = buildHuffmanTree(freqMap, order);

    // Шаг 3
    unordered_map<char, string> huffmanCode;
    generateHuffmanCodes(root, "", huffmanCode);

    cout << "\nТаблица соответствия символов и кодов:\n";
    for (auto& pair : huffmanCode) {
        cout << "'" << pair.first << "' -> " << pair.second << "\n";
    }

    // Шаг 4
    string encodedString = "";
    for (char ch : text) {
        encodedString += huffmanCode[ch];
    }

    cout << "\nВыходная последовательность:\n";
    cout << encodedString << endl;

    deleteTree(root);
    return 0;
}
