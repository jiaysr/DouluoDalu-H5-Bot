Function 释放附件到指定目录(dirPath, fileName)
    If dirPath = "" Or dirPath = Null Then
        dirPath = GetSdcardDir()
    End If
    If fileName = "" Or fileName = Null Then
        fileName = "分辨率坐标.json"
    End If

    Dim path, content
    path = dirPath & "/" & fileName
    If dir.Exist(path) Then 
        dir.Delete(path)
        TracePrint "旧配置文件已删除: " & path
    End If
    PutAttachment GetSdcardDir(), fileName
    TracePrint "尝试释放配置文件到: " & path
    
    // 3. 读取文件内容
    content = File.Read(path)
    
    // 4. 打印文件内容
    If content <> "" And content <> Null Then
        TracePrint "配置文件内容读取成功："
        TracePrint content
    Else
        TracePrint "配置文件内容为空或读取失败！请检查附件中是否存在 " & fileName
    End If
    释放附件到指定目录 = content
End Function

Function 加载分辨率配置文件(w, h, dirPath, fileName)
    If dirPath = "" Or dirPath = Null Then
        dirPath = GetSdcardDir()
    End If
    If fileName = "" Or fileName = Null Then
        fileName = "分辨率坐标.json"
    End If

    Dim content
    content = 释放附件到指定目录(dirPath, fileName)

    Dim config_table, res_key, res_config
    If content <> "" And content <> Null Then
        config_table = Encode.JsonToTable(content)
        res_key = w & "*" & h

        If config_table[res_key] Then
            res_config = config_table[res_key]
            加载分辨率配置文件 = res_config
        Else
            加载分辨率配置文件 = Null
            Dialog.MsgBox("该脚本暂未支持该分辨率: " & res_key & "，请修改分辨率或联系脚本作者", 0)
        End If
    Else
        加载分辨率配置文件 = Null
    End If
End Function
