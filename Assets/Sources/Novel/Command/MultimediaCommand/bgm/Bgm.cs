﻿/*
MIT License

Copyright (c) 2022 ShuheiOi

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

 */
using System;
namespace AdolescenceNovel
{
    [Serializable]
    public class Bgm : MultimediaCommand
    {
        public IValue soundName;
        public IValue volumeTag;

        private IBgmContext state;

        public Bgm(IValue soundName)
        {
            this.soundName = soundName;
            this.volumeTag = new StringValue(ConstData.VolumeMaster);
            state = new BgmContext();
        }

        public Bgm(IValue soundName,IValue volumeTag)
        {
            this.soundName = soundName;
            this.volumeTag = volumeTag;
            state = new BgmContext();
        }

        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            return state.Execute(this);
        }
    }
}