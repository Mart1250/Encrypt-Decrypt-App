# Encrypt-Decrypt---App
Encrypts and Decrypts files using AES Encryption.

It does what the title says, you will see some unrelated class files that has nothing to do with the core functionality, just some testing. Verify button is not implemented right now, although you find some odd code about it.

The Encrypt and Decrypt functions are copied from this page: https://ourcodeworld.com/articles/read/471/how-to-encrypt-and-decrypt-files-using-the-aes-encryption-algorithm-in-c-sharp

Although slightly modified, the decrypt function does not implement the salt that is generated at encryption time. The function as it is posted there just doesn't work. You will get padding errors.
