using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextReader {

    public static class TextReader {
        public static string readTextFile(TextAsset file) {
            return file.text;
        }
    }
}
