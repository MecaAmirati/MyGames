from random import randrange
from time import sleep
player = int(input('\nVamos jogar!\n[1] Pedra\n[2] Papel\n[3] Tesoura\nEscolha: '))
ia = randrange(1, 4)
print('\nJO')
sleep(1)
print('KEN!')
sleep(1)
print('PO!!!\n')
if   player == 1 and ia == 3:
    print('\033[30;42m VITÓRIA! \033[m')
    print('Humano escolheu PEDRA\nComputador escolheu TESOURA')
elif player == 1 and ia == 2:
    print('\033[030;041m DERROTA! \033[m')
    print('Humano escolheu PEDRA\nComputador jogou PAPEL')
elif player == 1 and ia == 1:
    print('\033[030;043m EMPATE! \033[m')
    print('Humano escolheu PEDRA\nComputador jogou PEDRA')

elif player == 2 and ia == 1:
    print('\033[30;42m VITÓRIA! \033[m')
    print('Humano escolheu PAPEL\nComputador escolheu PEDRA')
elif player == 2 and ia == 3:
    print('\033[030;041m DERROTA! \033[m')
    print('Humano escolheu PAPEL\nComputador escolheu TESOURA')
elif player == 2 and ia == 2:
    print('\033[030;043m EMPATE! \033[m')
    print('Humano escolheu PAPEL\nComputador escolheu PAPEL')

elif player == 3 and ia == 2:
    print('\033[30;42m VITÓRIA! \033[m')
    print('Humano escolheu TESOURA\nComputador escolheu PAPEL')
elif player == 3 and ia == 1:
    print('\033[030;041m DERROTA! \033[m')
    print('Humano escolheu TESOURA\nComputador escolheu PEDRA')
elif player == 3 and ia == 3:
    print('\033[030;043m EMPATE! \033[m')
    print('Humano escolheu TESOURA\nComputador escolheu TESOURA')
else:
    print('\033[030;041m ERRO! \033[m\n\033[030;041m Opção inválida! \033[m')

#[1] Pedra [2] Papel [3] Tesoura