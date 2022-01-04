import os
import cv2

PATH = "D:/Program Files (x86)/Steam/steamapps/common/Tabletop Simulator/Tabletop Simulator_Data/Mods/Images/"
TARGET = "E:/GitHub/AHLCG/resources/temp/"
WIDTH = 750
HEIGHT = 1050


def changeName():
    s = input("Input:")
    s = s.replace(".", "")
    s = s.replace("/", "")
    s = s.replace(":", "")
    s = s.replace("-", "")
    print(s)
    return s


def main():
    counter = 0
    while True:
        name = changeName()
        img = cv2.imread(PATH + name + ".jpg")
        print(img.shape)
        for i in range(70):
            up = (i // 10) * HEIGHT
            left = (i % 10) * WIDTH
            cropped = img[up : up + HEIGHT, left : left + WIDTH]
            cv2.imwrite(TARGET + str(counter) + str(i) + ".jpg", cropped)


if __name__ == "__main__":
    main()
