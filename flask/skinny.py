from PIL import Image
import csv
import sys

#i = sys.argv[0]
# i = "test3.png"

def Histogram(items):
    counts = dict()
    
    for j in range(256):
        counts[j] = 0
        
    for i in items:
        counts[i] = counts.get(i, 0) + 1
        
    return counts

def structure(values):
    r = []
    g = []
    b = []
    for i in range(len(values)):
        if i == 0 or i%3 == 0:
            r.append(int(values[i]))
            g.append(int(values[i+1]))
            b.append(int(values[i+2]))
            
    return r,g,b  

def Average(a, b, c):
    final_dict = {}
    
    for z in range(256):
        sumA = a[z] + b[z] + c[z]
        
        
        average = sumA / 3
        
        final_dict[z] = round(average)
        
    return final_dict 

def Difference(test_R, test_G, test_B, r, g, b):
    sumOfDifference = 0
    
    for i in range(256):
        rDifference = abs(test_R[i] - r[i])
        gDifference = abs(test_G[i] - g[i])
        bDifference = abs(test_B[i] - b[i])
        
        sumOfDifference = sumOfDifference + rDifference + gDifference + bDifference 
        
    return sumOfDifference

def classify_lesion(photo):
    image = Image.open(photo)
    resized_image = image.resize((8,8))
    
    pixel_list = []
    image = resized_image.convert('RGB')
    for i in range(8):
        for a in range(8):
            pixel_list.append(image.getpixel((i,a)))   
            
    p_r = []
    p_g = []
    p_b = []

    for i in range(64):
        p_r.append(pixel_list[i][0])
        p_g.append(pixel_list[i][1])
        p_b.append(pixel_list[i][2])
        
    p_r = Histogram(p_r)
    p_g = Histogram(p_g)
    p_b = Histogram(p_b)    
    
    with open('skin rgb.csv', newline = '') as f:
        reader = csv.reader(f)
        _list = list(reader) 
    
    
    blk = _list[0:9]
    df = _list[9:14]
    mel = _list[15:18]
    vasc = _list[18:24]
    bcc = _list[24:27]
    nv = _list[27:36]
    akiec = _list[36:39]
    
    blk_r,blk_g,blk_b = structure(blk[0])
    blk1_r,blk1_g,blk1_b = structure(blk[1])
    blk2_r,blk2_g,blk2_b = structure(blk[2])

    blk_r = Histogram(blk_r)
    blk1_r = Histogram(blk1_r)
    blk2_r = Histogram(blk2_r)

    blk_g = Histogram(blk_g)
    blk1_g = Histogram(blk1_g)
    blk2_g = Histogram(blk2_g)

    blk_b = Histogram(blk_b)
    blk1_b = Histogram(blk1_b)
    blk2_b = Histogram(blk2_b)
    
    df_r, df_g, df_b = structure(df[0])
    df_r1, df_g1, df_b1 = structure(df[1])
    df_r2, df_g2, df_b2 = structure(df[2])

    df_r = Histogram(df_r)
    df_r1 = Histogram(df_r1)
    df_r2 = Histogram(df_r2)

    df_g = Histogram(df_g)
    df_g1 = Histogram(df_g1)
    df_g2= Histogram(df_g2)

    df_b = Histogram(df_b)
    df_b1 = Histogram(df_b1)
    df_b2 = Histogram(df_b2)
    
    mel_r, mel_g, mel_b = structure(mel[0])
    mel_r1, mel_g1, mel_b1 = structure(mel[1])
    mel_r2, mel_g2, mel_b2 = structure(mel[2])

    mel_r = Histogram(mel_r)
    mel_r1 = Histogram(mel_r1)
    mel_r2 = Histogram(mel_r2)

    mel_g = Histogram(mel_g)
    mel_g1 = Histogram(mel_g1)
    mel_g2 = Histogram(mel_g2)

    mel_b = Histogram(mel_b)
    mel_b1 = Histogram(mel_b1)
    mel_b2 = Histogram(mel_b2)
    
    vasc_r, vasc_g, vasc_b = structure(vasc[0])
    vasc_r1, vasc_g1, vasc_b1 = structure(vasc[1])
    vasc_r2, vasc_g2, vasc_b2 = structure(vasc[2])

    vasc_r = Histogram(vasc_r)
    vasc_r1 = Histogram(vasc_r1)
    vasc_r2 = Histogram(vasc_r2)

    vasc_g = Histogram(vasc_g)
    vasc_g1 = Histogram(vasc_g1)
    vasc_g2 = Histogram(vasc_g2)

    vasc_b = Histogram(vasc_b)
    vasc_b1 = Histogram(vasc_b1)
    vasc_b2 = Histogram(vasc_b2)
        
    bcc_r, bcc_g, bcc_b = structure(bcc[0])
    bcc_r1, bcc_g1, bcc_b1 = structure(bcc[1])
    bcc_r2, bcc_g2, bcc_b2 = structure(bcc[2])

    bcc_r = Histogram(bcc_r)
    bcc_r1 = Histogram(bcc_r1)
    bcc_r2 = Histogram(bcc_r2)

    bcc_g = Histogram(bcc_g)
    bcc_g1 = Histogram(bcc_g1)
    bcc_g2 = Histogram(bcc_g2)

    bcc_b = Histogram(bcc_b)
    bcc_b1 = Histogram(bcc_b1)
    bcc_b2 = Histogram(bcc_b2)
    
    nv_r, nv_g, nv_b = structure(nv[0])
    nv_r1, nv_g1, nv_b1 = structure(nv[1])
    nv_r2, nv_g2, nv_b2 = structure(nv[2])

    nv_r = Histogram(nv_r)
    nv_r1 = Histogram(nv_r1)
    nv_r2 = Histogram(nv_r2)

    nv_g = Histogram(nv_g)
    nv_g1 = Histogram(nv_g1)
    nv_g2 = Histogram(nv_g2)

    nv_b = Histogram(nv_b)
    nv_b1 = Histogram(nv_b1)
    nv_b2 = Histogram(nv_b2)
    
    akiec_r, akiec_g, akiec_b = structure(akiec[0])
    akiec_r1, akiec_g1, akiec_b1 = structure(akiec[1])
    akiec_r2, akiec_g2, akiec_b2 = structure(akiec[2])

    akiec_r = Histogram(akiec_r)
    akiec_r1 = Histogram(akiec_r1)
    akiec_r2 = Histogram(akiec_r2)

    akiec_g = Histogram(akiec_g)
    akiec_g1 = Histogram(akiec_g1)
    akiec_g2 = Histogram(akiec_g2)

    akiec_b = Histogram(akiec_b)
    akiec_b1 = Histogram(akiec_b1)
    akiec_b2 = Histogram(akiec_b2)
    
    nv_r, nv_g, nv_b = structure(nv[0])
    nv_r1, nv_g1, nv_b1 = structure(nv[1])
    nv_r2, nv_g2, nv_b2 = structure(nv[2])

    nv_r = Histogram(nv_r)
    nv_r1 = Histogram(nv_r1)
    nv_r2 = Histogram(nv_r2)

    nv_g = Histogram(nv_g)
    nv_g1 = Histogram(nv_g1)
    nv_g2 = Histogram(nv_g2)

    nv_b = Histogram(nv_b)
    nv_b1 = Histogram(nv_b1)
    nv_b2 = Histogram(nv_b2)
    
    
    blk_rA = Average(blk_r, blk1_r, blk2_r)
    blk_gA = Average(blk_g, blk1_g, blk2_g)
    blk_bA = Average(blk_b, blk1_b, blk2_b)
    
    df_rA = Average(df_r, df_r1, df_r2)
    df_gA = Average(df_g, df_g1, df_g2)
    df_bA = Average(df_b, df_b1, df_b2)
    
    mel_rA = Average(mel_r, mel_r1, mel_r2)
    mel_gA = Average(mel_g, mel_g1, mel_g2)
    mel_bA = Average(mel_b, mel_b1, mel_b2)
    
    vasc_rA = Average(vasc_r, vasc_r1, vasc_r2)
    vasc_gA = Average(vasc_g, vasc_g1, vasc_g2)
    vasc_bA = Average(vasc_b, vasc_b1, vasc_b2)
    
    bcc_rA = Average(bcc_r, bcc_r1, bcc_r2)
    bcc_gA = Average(bcc_g, bcc_g1, bcc_g2)
    bcc_bA = Average(bcc_b, bcc_b1, bcc_b2)
    
    nv_rA = Average(nv_r, nv_r1, nv_r2)
    nv_gA = Average(nv_g, nv_g1, nv_g2)
    nv_bA = Average(nv_b, nv_b1, nv_b2)
    
    akiec_rA = Average(akiec_r, akiec_r1, akiec_r2)
    akiec_gA = Average(akiec_g, akiec_g1, akiec_g2)
    akiec_bA = Average(akiec_b, akiec_b1, akiec_b2)
    
    blk_diff = Difference(p_r, p_g, p_b, blk_rA, blk_gA, blk_bA)
    df_diff = Difference(p_r, p_g, p_b, df_rA, df_gA, df_bA)
    mel_diff = Difference(p_r, p_g, p_b, mel_rA, mel_gA, mel_bA)
    vasc_diff = Difference(p_r, p_g, p_b, vasc_rA, vasc_gA, vasc_bA)
    bcc_diff = Difference(p_r, p_g, p_b, bcc_rA, bcc_gA, bcc_bA)
    akiec_diff = Difference(p_r, p_g, p_b, akiec_rA, akiec_gA, akiec_bA)
    nv_diff = Difference(p_r, p_g, p_b, nv_rA, nv_gA, nv_bA)
    
    com = dict()
    com['blk'] = blk_diff
    com['df'] = df_diff
    com['mel'] = mel_diff
    com['vasc'] = vasc_diff
    com['bcc'] = bcc_diff
    com['akiec'] = akiec_diff
    com['nv'] = nv_diff

    return com
    
    # result = min(com, key=com.get)
    
    # cases = dict()
    # cases['blk'] = 'Benign Keratosis-Like Lesions'
    # cases['df'] = 'Dermatofibroma'
    # cases['mel'] = 'Melanoma'
    # cases['bcc'] = 'Basal Cell Carcinoma'
    # cases['akiec'] = 'Actinic Keratoses and Intraepithelial Carcinoma / Bowen Disease'
    # cases['vasc'] = 'Vascular'
    # cases['nv'] = 'Melanocytic Nevi'
    
    # # dignosis = """Our image processing model has determined that you case is closest to the {} skin cancer type.
    # # It is important to understand that all diagnosis may not be final. It is vital to consult with a doctor
    # # about any worries of possible skin cancer cases. To further understand the symptoms and general information
    # # about your disgnosis, visit the Confirmed Cases tab."""
   
    # # d = dignosis.format(cases[result])
    
    # d = cases[result]

    # print(d)
    # return d

# main(i)
