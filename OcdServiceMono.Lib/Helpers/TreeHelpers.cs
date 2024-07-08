using OcdServiceMono.Lib.Abstracts;
using OcdServiceMono.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OcdServiceMono.Lib.Helpers
{
    public class TreeHelpers<T> where T : absTree<T>
    {
        private static int NodeLevel(T nodeChild, List<T> listData)
        {
            int level = -1;
            while (nodeChild != null)
            {
                var nodeParent = listData.FirstOrDefault(o => o.Id == nodeChild.ParentId);
                nodeChild = nodeParent;
                level++;
            }
            return level < 0 ? 0 : level;
        }
        public static List<T> ListToTrees(List<T> listData, bool isShowLevelNodes = false, string rootId = "", string symbolLevel = "-", int startLevel = 0)
        {
            List<T> treeData = new List<T>();
            Dictionary<string, int> map = new Dictionary<string, int>();
            int lenthData = listData.Count;
            T parentNode = null, node = null;
            for (int i = 0; i < lenthData; i++)
            {
                if (isShowLevelNodes)
                {                    
                    int level = NodeLevel(listData[i], listData) + 1;
                    level = level - startLevel;
                    listData[i].NodeLevel = level;                    
                    listData[i].Name = listData[i].Name.MultiInsert(symbolLevel, level - 1, 0);
                }
                map.Add(listData[i].Id, i);
            }
            for (int i = 0; i < lenthData; i++)
            {
                node = listData[i];
                parentNode = listData.Where(o => o.Id == node.ParentId).FirstOrDefault();
                if (parentNode != null)
                {
                    node.ParentName = parentNode.Name;
                }
                if (string.IsNullOrEmpty(node.ParentId) || node.ParentId == Guid.Empty.ToString())
                {
                    treeData.Add(node);
                }
                else
                {
                    if (map.ContainsKey(node.ParentId))
                    {
                        listData[map[node.ParentId]].Children.Add(node);
                    }
                }
            }
            if (!string.IsNullOrEmpty(rootId))
            {
                treeData = new List<T>();
                for (int i = 0; i < lenthData; i++)
                {
                    node = listData[i];
                    parentNode = listData.Where(o => o.Id == node.ParentId).FirstOrDefault();
                    if (parentNode != null)
                    {
                        node.ParentName = parentNode.Name;
                    }
                    if (node.Id == rootId)
                    {
                        treeData.Add(node);
                        break;
                    }    
                }
            }
            return treeData;
        }
        public static List<T> GetListNodesByNodeParent(T parentNode)
        {
            List<T> nodes = new List<T>();
            RecursiveNodesToList(parentNode, parentNode, nodes);
            return nodes;
        }

        private static void RecursiveNodesToList(T node, T parentNode, List<T> nodes)
        {
            if (node.Id != parentNode.Id)
            {
                nodes.Add(node);
            }
            if (node.Children != null)
            {
                for (int i = 0; i < node.Children.Count; i++)
                {
                    RecursiveNodesToList(node.Children[i], parentNode, nodes);
                }
            }
        }
        public static T GetNodeFromTree(T rootTree, string nodeId)
        {
            if(rootTree.Id == nodeId)
            {
                return rootTree;
            }    
            else if(rootTree.Children != null)
            {
                T node = null;
                for(int i = 0;node == null && i < rootTree.Children.Count;i++)
                {
                    node = GetNodeFromTree(rootTree.Children[i], nodeId);
                }
                return node;
            }  
            return null;
        }
        public static void InsertNodeIntoTree(T rootTree, string nodeId, T newNode)
        {
            if (rootTree.Id == nodeId && newNode != null)
            {
                rootTree.Children.Add(newNode);
            }
            else if (rootTree.Children != null)
            {                
                for (int i = 0;i < rootTree.Children.Count; i++)
                {
                    InsertNodeIntoTree(rootTree.Children[i], nodeId, newNode);
                }                
            }
        }
        public static void UpdateNodeIntoTree(T rootTree, string nodeId, T updateNode)
        {
            if (rootTree.Id == nodeId && updateNode != null)
            {
                rootTree.Code = updateNode.Code;
                rootTree.Name = updateNode.Name;                
                rootTree.NodeLevel = updateNode.NodeLevel;
                rootTree.ParentId = updateNode.ParentId;
                rootTree.Children = updateNode.Children;
            }
            else if (rootTree.Children != null)
            {
                for (int i = 0; i < rootTree.Children.Count; i++)
                {
                    UpdateNodeIntoTree(rootTree.Children[i], nodeId, updateNode);
                }
            }
        }
        public static void DeleteNodeInTree(T rootTree, string nodeId)
        {
            if (rootTree.Children.Count > 0)
            {
                for(int i = 0;i < rootTree.Children.Count;i++)
                {
                    var filtered = rootTree.Children.Where(f => f.Id == nodeId).ToList();
                    if (filtered != null && filtered.Count() > 0)
                    {
                        rootTree.Children = rootTree.Children.Where(f => f.Id != nodeId).ToList();
                        return;
                    }
                    DeleteNodeInTree(rootTree.Children[i], nodeId);
                }    
            }
        }
    }
}
