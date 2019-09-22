# SOFTENG306 Project 2 Group 11

## Team Members

| Name           | GitHub Username  | UoA UPI |
| -------------- | ---------------- | ------- |
| Harrison Leach | HarrisonLeach1   | hlea849 |
| Willian Li     | TwelveHertz      | zli667  |
| Nidhinesh Nand | nidhineshnand    | nnan773 |
| Allen Nian     | anian100         | ania716 |
| William Shin   | william-shin-387 | wshi593 |
| Casey Wong     | cwon880          | cwon880 |
| James Zhang    | JamesUOA         | jzha414 |

## Setting up

### Setup Untiy file merging

1. Add the following text to your `~/.gitconfig` file.

```
[merge] tool = unityyamlmerge
[mergetool "unityyamlmerge"]
    trustExitCode = false
    cmd = 'C:\\Program Files\\Unity\\Editor\\Data\\Tools\\UnityYAMLMerge.exe' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
```

> **The path above may have to be modified to fit your environment**

For Mac, use the following path instead:

```
/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge
```

### Setup Git LFS

1. Download and install the Git LFS command line tool [here](https://git-lfs.github.com/)
2. Run the following command in the repository:

```
git lfs install
```

### Adding new binaries

If adding new type of binary file, make sure to track it in Git LFS by running the following command:

```
git lfs track "*.<extension name>"
```
