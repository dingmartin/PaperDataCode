import networkx as nx

num= #the number of street blocks
pSArray=[ 0 for x in range(num)]
for i in range(1,num):
    pSArray[i]=0
    
G = nx.Graph()
#import the connectivity graph of street blocks,
#each edge indicates that two polygons touch with each other. 
address="connectGraph.txt"
ins = open(address, "r")
for line in ins:
    words = line.split(' ')
    G.add_edge(int(words[0]), int(words[1]))
ins.close()


def isCityBlock(G,nid):
    listNeighbors=G.neighbors(nid) #get neighboring blocks of current block
    for uid in listNeighbors: # check if all the neighboring blocks are city blocks
            if #block uid is a field block:
                     return False
    return True

def cityDetection(G,nid,templist):
    if pSArray[nid] == 0: # check if current block has been processed
       if isCityBlock(G,nid): # check if current block is a city block
            templist.append(nid)
            pSArray[nid] = 1 # mark this block as processed
            listNeighbors=G.neighbors(nid) # continually process its neighboring blocks
            for uid in listNeighbors:
                cityDetection(G,uid,templist)

print "load complete"

CityList=[]
while(i < num-1):
     templist=[]
     cityDetection(G,i,templist)
     if len(templist)> 0:
         templist2=list(set(templist)) # remove duplicates in the list
         Citylist.append(templist2)
     else:
         pSArray[i] = 0

#write clustering result in a .txt file     
Address1="citylist.txt"
text_file = open(Address1, "w")
for i in range(0,len(Citylist)):
    listWrite=Citylist[i]
    for x in listWrite:
       text_file.write(str(x)+",")
    text_file.write("\n")
text_file.close()

print "Clustering Complete"

