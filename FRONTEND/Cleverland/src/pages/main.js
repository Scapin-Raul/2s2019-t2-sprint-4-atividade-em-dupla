import React, {Component} from 'react';
import {StyleSheet,View,Text,Picker} from 'react-native';
import {FlatList} from 'react-native-gesture-handler';

class Main extends Component {
  
//   static navigationOptions={
//     tabBarIcon: ()=>(
//       <Image source={require('../assets/img/calendar.png')}
//       style={styles.ImagemIcone}/>
//     )
//   }

  constructor() {
    super();
    this.state = {
        especialidadeSelecionada: "",
        medicos: [],
        especialidade:[
          {id:1, nome: 'Ginecologista'},
          {id:2, nome: 'Clinico geral'},
          {id:3, nome: 'Cardiologista'},
          {id:4, nome: 'Pediatra'}
        ]
    }
  }

  componentDidMount() {
    this._carregarMedicos();
  }

  _carregarMedicos = async () => {
    await fetch('http://192.168.4.203:5000/api/medicos')
      .then(resposta => resposta.json())
      .then(data => this.setState({medicos: data}))
      .catch(erro => console.warn(erro));
  };
  
  _filtrar = async (itemValue) =>{
      this.setState({especialidadeSelecionada: itemValue});
      this._carregarMedicos;
      
      var listaMedicosFiltrado = [];
      this.state.medicos.forEach(e => {
          if(e.especialidade == itemValue) listaMedicosFiltrado.push(e)
        });
        
    // console.warn(listaMedicosFiltrado);
      this.setState({medicos: listaMedicosFiltrado});

  }

  render() {
    return (
        <View style>
            <Text style={{fontWeight: 'bold', textAlign: "center"}}>MEDICOS AQUI MESMOAWJR07Q8O0PTG</Text>

            <Picker selectedValue={this.state.especialidadeSelecionada} onValueChange={(itemValue) => this._filtrar(itemValue)}>
                <Picker.item label="Especialidade" value="0"/>
                {this.state.especialidade.map(e => {
                    return( <Picker.item label={e.nome} value={e.nome}/>
                        )})}
            </Picker>
            
            <View style={styles.organizador}>
                <Text>CRM</Text>
                <Text>Nome</Text>
                <Text>Data Nascimento</Text>
                <Text>Ativo</Text>
                <Text>Especialidade</Text>
            </View>

            <FlatList
            data={this.state.medicos}
            keyExtractor={item => item.crm}
            renderItem={({item}) => (
                <View style={styles.borda}>
                <Text>{item.crm}</Text>
                <Text>{item.nome}</Text>
                <Text>{item.dataNascimento}</Text>
                <Text>{item.ativo == true? 'Ativo' : 'Não ativo'}</Text>
                <Text>{item.especialidade}</Text>
            </View>
            )}
            />
        </View>
    );
  }
}

const styles = StyleSheet.create({
    borda:
    {
        flexDirection: "row",
        justifyContent: "space-between",
        borderColor:'black',
        borderBottomWidth:1,
        borderTopWidth:1,
        padding: 10,
        marginBottom: 5,
    },
    organizador:{
        flexDirection: "row",
        justifyContent: "space-between",

    }

});

export default Main;
